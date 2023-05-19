using Core.Business.Abstract;
using Entities.Concrete;
using Entities.Models.ResponseModels;

namespace Business.Abstract
{
    public interface IMovieService : IExtendedServiceRepository<Movie>
    {
        Task<List<Movie>> GetByActor(int actorId);
        Task<List<Movie>> GetByDirector(int directorId);
        Task<MovieResponseModel> GetMovieById(int id);
        Task<List<MovieResponseModel>> GetMovies();
        Task<MovieResponseModel> GetRandomMovie();
    }
}
