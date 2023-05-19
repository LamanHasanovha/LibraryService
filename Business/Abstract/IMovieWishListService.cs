using Core.Business.Abstract;
using Entities.Concrete;
using Entities.Models.ResponseModels;

namespace Business.Abstract
{
    public interface IMovieWishListService : IExtendedServiceRepository<MovieWishList>
    {
        Task<List<MovieResponseModel>> GetByAccount(int id);
        Task RemoveByAccount(int accountId, int movieId);
    }
}
