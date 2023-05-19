using Core.Business.Abstract;
using Entities.Concrete;
using Entities.Models.ResponseModels;

namespace Business.Abstract
{
    public interface IBookFavListService : IExtendedServiceRepository<BookFavList>
    {
        Task<List<BookResponseModel>> GetByAccount(int id);
        Task RemoveByAccount(int accountId, int bookId);
    }
}
