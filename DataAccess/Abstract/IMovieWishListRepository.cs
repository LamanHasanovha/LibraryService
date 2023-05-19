using Core.DataAccess.Repositories;
using Entities.Concrete;
using Entities.Models.ResponseModels;

namespace DataAccess.Abstract
{
    public interface IMovieWishListRepository : IExtendedRepository<MovieWishList>
    {
        Task<List<MovieResponseModel>> GetByAccount(int id);
    }
}
