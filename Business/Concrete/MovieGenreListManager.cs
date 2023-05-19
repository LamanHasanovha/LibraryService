using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MovieGenreListManager : ManagerRepositoryBase<MovieGenreList, IMovieGenreListRepository>, IMovieGenreListService
    {
        public MovieGenreListManager(IMovieGenreListRepository repository) : base(repository)
        {
            //base.SetValidator(new MovieGenreListValidator());
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

        public async Task<List<MovieGenreList>> GetByMovie(int id)
        {
            return await Repository.GetAllAsync(l=>l.MovieId == id);
        }

        public async Task<List<MovieGenreList>> UpdateByMovie(List<MovieGenreList> list)
        {

            if (list.Count == 0)
                return await Task.FromResult(new List<MovieGenreList>());

            await DeleteByMovie(list[0].MovieId);
            var result = new List<MovieGenreList>();
            foreach (var item in list)
            {
                result.Add(await Repository.AddAsync(item));
            }

            return result;
        }
    }
}
