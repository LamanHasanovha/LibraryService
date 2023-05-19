using Core.DataAccess.Repositories;
using Entities.Concrete;
using Entities.Models.ResponseModels;

namespace DataAccess.Abstract
{
    public interface ICartRepository : IExtendedRepository<Cart>
    {
        Task<List<CartResponseModel>> GetByAccount(int id);
    }
}
