using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfBookGenreRepository : EfRepositoryBase<BookGenre, LibraryContext>, IBookGenreRepository
    {
        public EfBookGenreRepository(LibraryContext context) : base(context)
        {
        }
    }
}
