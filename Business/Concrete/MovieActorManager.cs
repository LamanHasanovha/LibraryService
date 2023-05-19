using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MovieActorManager : ManagerRepositoryBase<MovieActor, IMovieActorRepository>, IMovieActorService
    {
        public MovieActorManager(IMovieActorRepository repository) : base(repository)
        {
            //base.SetValidator(new MovieActorValidator());
        }

        public async Task<int> DeleteByMovie(int id)
        {
            var list = await Repository.GetAllAsync(l => l.MovieId == id);

            foreach (var movie in list)
            {
                await Repository.DeleteAsync(movie);
            }

            return await Task.FromResult(list.Count);
        }

        public async Task<List<MovieActor>> GetByMovie(int id)
        {
            return await Repository.GetAllAsync(m=>m.MovieId == id);
        }

        public async Task<List<MovieActor>> UpdateByMovie(List<MovieActor> list)
        {
            if (list.Count == 0)
                return await Task.FromResult(new List<MovieActor>());

            await DeleteByMovie(list[0].MovieId);
            var result = new List<MovieActor>();
            foreach (var item in list)
            {
                result.Add(await Repository.AddAsync(item));
            }

            return result;
        }
    }
}
