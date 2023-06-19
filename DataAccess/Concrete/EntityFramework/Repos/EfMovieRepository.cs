using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Entities.Constants;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfMovieRepository : EfRepositoryBase<Movie, LibraryContext>, IMovieRepository
    {
        public EfMovieRepository(LibraryContext context) : base(context)
        {

        }

        public async Task<List<Movie>> GetByActor(int actorId)
        {
            var result = await Context.MovieActors.Where(m=>m.ActorId == actorId).ToListAsync();

            var data = await Context.Movies.Where(m => result.Select(r => r.MovieId).Contains(m.Id)).ToListAsync();

            return data;
        }

        public async Task<List<Movie>> GetByIds(List<int> result)
        {
            return await Context.Movies.Where(m => result.Contains(m.Id)).ToListAsync();
        }

        public async Task<string> GetMaxMinValue()
        {
            var maxValue = await Context.Movies.MaxAsync(m => m.Price);
            var minValue = await Context.Movies.MinAsync(m => m.Price);

            return maxValue.ToString() + "-" + minValue.ToString();
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

        public async Task<List<MovieResponseModel>> GetPopularMovies()
        {
            var topSellers = Context.Purchases.Where(p => p.ProductType == ProductTypes.Movie).GroupBy(p => p.RecordId).Select(g => new { MovieId = g.Key, TotalSales = g.Count() })
                                    .OrderByDescending(p => p.TotalSales).Where(g => g.TotalSales > 5).Take(10)
                                    .Join(Context.Movies.Include(m => m.Director).Include(m => m.MovieGenreLists).ThenInclude(mg => mg.MovieGenre).Include(m => m.MovieActors).ThenInclude(ma => ma.Actor),
                                    m => m.MovieId, movie => movie.Id, (m, movie) => new { Book = movie, m.TotalSales });

            var result = from m in Context.Movies.Include(m => m.Director).Include(m => m.MovieGenreLists).ThenInclude(mg => mg.MovieGenre).Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
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

            if (data.Count < 10)
            {
                var topRateds = Context.Ratings.Where(r => r.Type == RatingTypes.Movie & r.Value > 2).GroupBy(r => r.RecordId).Select(g => new { MovieId = g.Key, TotalRates = g.Count() })
                                       .OrderByDescending(r => r.TotalRates).Where(g => g.TotalRates > 5).Take(10)
                                       .Join(Context.Movies.Include(m => m.Director).Include(m => m.MovieGenreLists).ThenInclude(mg => mg.MovieGenre).Include(m => m.MovieActors).ThenInclude(ma => ma.Actor),
                                       m => m.MovieId, movie => movie.Id, (m, movie) => new { Movie = movie, m.TotalRates });

                var result2 = from m in Context.Movies.Where(b => topRateds.Select(s => s.Movie.Id).Contains(b.Id)).Include(m => m.Director).Include(m => m.MovieGenreLists).ThenInclude(mg => mg.MovieGenre).Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
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
                data.AddRange(await result2.ToListAsync());
            }

            if (data.Count < 10)
            {
                var topVisiteds = Context.Activities.Where(a => a.ProductType == ProductTypes.Movie).GroupBy(a => a.RecordId).Select(g => new { MovieId = g.Key, TotalVisits = g.Count() })
                                         .OrderByDescending(a => a.TotalVisits).Where(g => g.TotalVisits > 10).Take(10)
                                         .Join(Context.Movies.Include(m => m.MovieGenreLists).ThenInclude(mg => mg.MovieGenre).Include(m => m.MovieActors).ThenInclude(ma => ma.Actor),
                                         m => m.MovieId, movie => movie.Id, (m, movie) => new { Movie = movie, m.TotalVisits });

                var result3 = from m in Context.Movies.Where(b => topVisiteds.Select(s => s.Movie.Id).Contains(b.Id)).Include(m => m.Director).Include(m => m.MovieGenreLists).ThenInclude(mg => mg.MovieGenre).Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
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
                data.AddRange(await result3.ToListAsync());
            }

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

        public async Task<List<Movie>> GetSameGenre(int movieId, int count)
        {
            var genres = (await Context.MovieGenreLists.Where(l => l.MovieId == movieId).ToListAsync()).Select(g => g.MovieGenreId);

            var movies = (await Context.MovieGenreLists.Where(l => genres.Contains(l.MovieGenreId)).ToListAsync()).Select(g => g.MovieId);

            return await Context.Movies.Where(m => movies.Contains(m.Id)).Take(count).ToListAsync();
        }
    }
}
