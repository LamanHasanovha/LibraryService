using Core.DataAccess.Repositories;
using Entities.Concrete;
using Entities.Models.ResponseModels;

namespace DataAccess.Abstract
{
    public interface IBookWishListRepository : IExtendedRepository<BookWishList>
    {
        Task<List<BookResponseModel>> GetByAccount(int id);
    }
}
