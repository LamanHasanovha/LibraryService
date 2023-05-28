using Business.Abstract;
using Core.Business.Concrete;
using Core.CCC.Exception;
using Core.Features.Mailing.MailKitImpelementations;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AuthCodeManager : ManagerRepositoryBase<AuthCode, IAuthCodeRepository>, IAuthCodeService
    {
        private IAccountService _accountService;

        public AuthCodeManager(IAuthCodeRepository repository, IAccountService accountService) : base(repository)
        {
            _accountService = accountService;
            //base.SetValidator(new AuthCodeValidator());
        }

        public async Task<bool> CheckAuthCode(int accountId, string code)
        {
            var authCode = await Repository.GetAsync(a => a.Code == code & a.CreatorAccountId == accountId) ?? throw new BusinessException("Auth code not found.");

            if ((DateTime.Now - authCode.CreateDate).TotalMinutes > 3)
                throw new BusinessException("Auth code was expired");

            authCode.IsUsed = true;
            authCode.CreatorAccountId = accountId;

            await Repository.UpdateAsync(authCode);

            return true;
        }

        public async Task SendAuthCode(int accountId, string email)
        {
            var code = await GenerateCode();

            var account = await _accountService.GetAsync(accountId);

            var mailHelper = new MailHelper("LemAy", "asim.alizada.9@gmail.com", "acuxbjicsdtnmceo", "smtp.gmail.com", 587, false);

            var result = await mailHelper.PublishAsync(new MailHelper.SendMailIntegrationEvent
            {
                IsHtmlBody = false,
                Body = code,
                Subject = "Your Auth Code [No-reply]",
                ToMails = new List<string>(new string[] { email })
            });

            if (!result)
                throw new BusinessException("Error while sending email. Please, try again");

            var authCode = new AuthCode
            {
                Code = code,
                CreateDate = DateTime.Now,
                CreatorAccountId = accountId,
                IsUsed = false
            };

            await Repository.AddAsync(authCode);
        }

        private async Task<string> GenerateCode()
        {
            var random = new Random();

            return await Task.FromResult(random.Next(100000000, 1000000000).ToString());
        }
    }
}
