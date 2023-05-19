using Core.Business.Abstract;
using Entities.Concrete;
using Entities.Models.ResponseModels;

namespace Business.Abstract
{
    public interface IBookWishListService : IExtendedServiceRepository<BookWishList>
    {
        Task<List<BookResponseModel>> GetByAccount(int id);
        Task RemoveByAccount(int accountId, int bookId);
    }
}
