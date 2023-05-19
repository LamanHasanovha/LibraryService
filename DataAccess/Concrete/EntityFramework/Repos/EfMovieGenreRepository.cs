using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfMovieGenreRepository : EfRepositoryBase<MovieGenre, LibraryContext>, IMovieGenreRepository
    {
        public EfMovieGenreRepository(LibraryContext context) : base(context)
        {
        }
    }
}
