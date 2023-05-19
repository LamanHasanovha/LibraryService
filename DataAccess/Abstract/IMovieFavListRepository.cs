using Core.DataAccess.Repositories;
using Entities.Concrete;
using Entities.Models.ResponseModels;

namespace DataAccess.Abstract
{
    public interface IMovieFavListRepository : IExtendedRepository<MovieFavList>
    {
        Task<List<MovieResponseModel>> GetByAccount(int id);
    }
}
