using Core.DataAccess.Repositories;
using Entities.Concrete;
using Entities.Models.ResponseModels;

namespace DataAccess.Abstract
{
    public interface IBookFavListRepository : IExtendedRepository<BookFavList>
    {
        Task<List<BookResponseModel>> GetByAccount(int id);
    }
}
