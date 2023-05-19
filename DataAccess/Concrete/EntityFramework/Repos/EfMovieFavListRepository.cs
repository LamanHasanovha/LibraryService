using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfMovieFavListRepository : EfRepositoryBase<MovieFavList, LibraryContext>, IMovieFavListRepository
    {
        public EfMovieFavListRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<List<MovieResponseModel>> GetByAccount(int id)
        {
            var query = from a in Context.Accounts.Include(a => a.MovieFavLists).ThenInclude(l => l.Movie).Where(a => a.Id == id)
                        select a.MovieFavLists.Select(l => l.Movie);

            var data = await query.FirstOrDefaultAsync();

            var result = new List<MovieResponseModel>();

            foreach (var item in data)
            {
                result.Add(await GetMovie(item.Id));
            }

            return result;
        }

        private async Task<MovieResponseModel> GetMovie(int id)
        {
            var result = from m in Context.Movies.Include(m => m.Director).Include(m => m.MovieGenreLists).ThenInclude(mg => mg.MovieGenre).Include(m => m.MovieActors).ThenInclude(ma => ma.Actor).Where(m => m.Id == id)
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
