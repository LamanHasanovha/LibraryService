using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Business.Concrete;
using Core.CCC.Exception;
using Core.Features.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Models.RequestModels;

namespace Business.Concrete
{
    public class AccountManager : ManagerRepositoryBase<Account, IAccountRepository>, IAccountService
    {
        public AccountManager(IAccountRepository repository) : base(repository)
        {
            //base.SetValidator(new AccountValidator());
        }

        [CacheRemoveAspect("get")]
        public async Task<Account> Login(AccountLoginModel model)
        {
            var accountToCheck = await Repository.GetAllAsync(a => a.Username == model.Username);
            var acc = accountToCheck.FirstOrDefault();

            if (acc == null)
                throw new AuthorizationException(Messages.AccountNotFound);

            if (!acc.Status)
                throw new AuthorizationException(Messages.BannedAccount);

            if (!HashingHelper.VerifyPasswordHash(model.Password, acc.PasswordHash, acc.PasswordSalt))
                throw new AuthorizationException(Messages.PasswordError);

            acc.LastLoginDate = DateTime.Now;
            await Repository.UpdateAsync(acc);

            return acc;
        }

        [CacheRemoveAspect("get")]
        public async Task<Account> Register(AccountRegisterModel model)
        {
            await AccountExists(model);
            HashingHelper.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var account = new Account
            {
                Email = model.Email,
                Username = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            await Repository.AddAsync(account);

            return account;
        }

        public async Task AccountExists(AccountRegisterModel model)
        {
            var result = await Repository.GetAllAsync(a => a.Username == model.Username | a.Email == model.Email);
            if (result.Any())
                throw new BusinessException(Messages.UserAlreadyExists);
        }

        [CacheRemoveAspect("get")]
        public async Task<Account> UpdateWithPassword(AccountUpdateModel model)
        {
            var result = await Repository.GetAsync(a=>a.Id !=  model.Id & (a.Username == model.Username | a.Email == model.Email));
            if(result is not null)
                throw new BusinessException(Messages.UserAlreadyExists);

            HashingHelper.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var acc = await Repository.GetAsync(a=>a.Id == model.Id);

            //var account = new Account
            //{
            //    Id = model.Id,
            //    Email = model.Email,
            //    Username = model.Username,
            //    FirstName = model.FirstName,
            //    LastName = model.LastName,
            //    PasswordHash = passwordHash,
            //    PasswordSalt = passwordSalt,
            //    LastLoginDate = acc.LastLoginDate,
            //    Status = model.Status
            //};
            acc.Id = model.Id;
            acc.Email = model.Email;
            acc.FirstName = model.FirstName;
            acc.LastName = model.LastName;
            acc.PasswordHash = passwordHash;
            acc.PasswordSalt = passwordSalt;
            acc.Status = model.Status;

            await Repository.UpdateAsync(acc);

            return acc;
        }

        public async Task<Account> UpdateInfo(AccountUpdateInfoRequestModel model)
        {
            var result = await Repository.GetAsync(a => a.Id != model.Id & (a.Username == model.UserName | a.Email == model.Email));
            if (result is not null)
                throw new BusinessException(Messages.UserAlreadyExists);

            var acc = await Repository.GetAsync(a => a.Id == model.Id);
            acc.FirstName = model.FirstName;
            acc.LastName = model.LastName;
            acc.Email = model.Email;
            acc.Username = model.UserName;

            await Repository.UpdateAsync(acc);

            return acc;
        }
    }
}
