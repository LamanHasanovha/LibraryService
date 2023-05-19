using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfMovieRepository : EfRepositoryBase<Movie, LibraryContext>, IMovieRepository
    {
        public EfMovieRepository(LibraryContext context) : base(context)
        {

        }

        public async Task<List<Movie>> GetByActor(int actorId)
        {
            var result = from m in Context.Actors.Include(a => a.MovieActors).ThenInclude(m => m.Movie).Where(a => a.Id == actorId)
                         select m;

            var data = await result.FirstOrDefaultAsync();

            return data?.Movies?.ToList();
        }

        public async Task<List<MovieResponseModel>> GetMovies(Expression<Func<Movie, bool>> predicate = null)
        {
            var result = from m in predicate == null
                                    ? Context.Movies.Include(m => m.Director).Include(m => m.MovieGenreLists).ThenInclude(mg => mg.MovieGenre).Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                                    : Context.Movies.Include(m => m.Director).Include(m => m.MovieGenreLists).ThenInclude(mg => mg.MovieGenre).Include(m => m.MovieActors).ThenInclude(ma => ma.Actor).Where(predicate)
                         select new MovieResponseModel
                         {
                             Id = m.Id,
                             Name = m.Name,
                             Description = m.Description,
                             Director = m.Director.FirstName + " " + m.Director.LastName,
                             Image = m.Image,
                             Imdb = m.Imdb,
                             Price = m.Price,
                             ReleaseDate = m.ReleaseDate,
                             Time = m.Time,
                             Genres = m.MovieGenreLists.Select(mg => mg.MovieGenre).ToList(),
                             Actors = m.MovieActors.Select(a => a.Actor).ToList()
                         };

            var data = await result.ToListAsync();

            return data;
        }

        public async Task<MovieResponseModel> GetRandomMovie()
        {
            var rand = new Random();
            int toSkip = rand.Next(1, Context.Movies.Count());
            var result = from m in Context.Movies.OrderBy(o => Guid.NewGuid()).Skip(toSkip).Take(1)
                             .Include(m => m.Director).Include(m => m.MovieGenreLists).ThenInclude(mg => mg.MovieGenre).Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                         select new MovieResponseModel
                         {
                             Id = m.Id,
                             Name = m.Name,
                             Description = m.Description,
                             Director = m.Director.FirstName + " " + m.Director.LastName,
                             Image = m.Image,
                             Imdb = m.Imdb,
                             Price = m.Price,
                             ReleaseDate = m.ReleaseDate,
                             Time = m.Time,
                             Genres = m.MovieGenreLists.Select(mg => mg.MovieGenre).ToList(),
                             Actors = m.MovieActors.Select(a => a.Actor).ToList()
                         };
            var data = await result.FirstOrDefaultAsync();

            return data;
        }
    }
}
