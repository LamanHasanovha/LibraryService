using Core.Business.Abstract;
using Entities.Concrete;
using Entities.Models.RequestModels;

namespace Business.Abstract
{
    public interface IMovieGenreListService : IExtendedServiceRepository<MovieGenreList>
    {
        Task<int> DeleteByMovie(int id);
        Task<List<MovieGenreList>> GetByMovie(int id);
        Task<List<MovieGenreList>> UpdateByMovie(List<MovieGenreListUpdateRequestModel> list);
    }
}
