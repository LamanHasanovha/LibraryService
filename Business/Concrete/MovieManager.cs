using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Models.ResponseModels;

namespace Business.Concrete
{
    public class MovieManager : ManagerRepositoryBase<Movie, IMovieRepository>, IMovieService
    {
        public MovieManager(IMovieRepository repository) : base(repository)
        {
            //base.SetValidator(new MovieValidator());
        }

        public async Task<List<Movie>> GetByActor(int actorId)
        {
            return await Repository.GetByActor(actorId);
        }

        public async Task<List<Movie>> GetByDirector(int directorId)
        {
            return await Repository.GetAllAsync(m => m.DirectorId == directorId);
        }

        public async Task<MovieResponseModel> GetMovieById(int id)
        {
            var data = await Repository.GetMovies(m=>m.Id == id);
            return data.FirstOrDefault();
        }

        public async Task<List<MovieResponseModel>> GetMovies()
        {
            return await Repository.GetMovies();
        }

        public async Task<MovieResponseModel> GetRandomMovie()
        {
            return await Repository.GetRandomMovie();
        }
    }
}
