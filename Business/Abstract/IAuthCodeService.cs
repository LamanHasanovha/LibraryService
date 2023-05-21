using Core.Business.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAuthCodeService : IExtendedServiceRepository<AuthCode>
    {
        Task SendAuthCode(int accountId);
        Task<bool> CheckAuthCode(int accountId, string code);
    }
}
