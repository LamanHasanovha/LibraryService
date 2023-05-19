using Core.Business.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMovieGenreListService : IExtendedServiceRepository<MovieGenreList>
    {
        Task<int> DeleteByMovie(int id);
        Task<List<MovieGenreList>> GetByMovie(int id);
        Task<List<MovieGenreList>> UpdateByMovie(List<MovieGenreList> list);
    }
}
