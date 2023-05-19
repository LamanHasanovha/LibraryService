using Core.Business.Abstract;
using Entities.Concrete;
using Entities.Constants;
using Entities.Models.ResponseModels;

namespace Business.Abstract
{
    public interface ICartService : IExtendedServiceRepository<Cart>
    {
        Task<bool> Check(int accountId, int recordId, ProductTypes type);
        Task<List<CartResponseModel>> GetByAccount(int id);
        Task RemoveByAccount(int accountId, int recordId, ProductTypes type);
    }
}
