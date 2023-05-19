using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfMovieGenreListRepository : EfRepositoryBase<MovieGenreList, LibraryContext>, IMovieGenreListRepository
    {
        public EfMovieGenreListRepository(LibraryContext context) : base(context)
        {
        }
    }
}
