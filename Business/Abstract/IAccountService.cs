using Core.Business.Abstract;
using Entities.Concrete;
using Entities.Models.RequestModels;

namespace Business.Abstract
{
    public interface IAccountService : IExtendedServiceRepository<Account>
    {
        Task<Account> Register(AccountRegisterModel model);
        Task<Account> Login(AccountLoginModel model);
        Task AccountExists(AccountRegisterModel model);
        Task<Account> UpdateWithPassword(AccountUpdateModel model);
        Task<Account> UpdateInfo(AccountUpdateInfoRequestModel model);
    }
}
