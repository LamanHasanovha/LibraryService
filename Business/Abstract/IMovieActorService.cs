using Core.Business.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMovieActorService : IExtendedServiceRepository<MovieActor>
    {
        Task<int> DeleteByMovie(int id);
        Task<List<MovieActor>> GetByMovie(int id);
        Task<List<MovieActor>> UpdateByMovie(List<MovieActor> list);
    }
}
