using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfBookGenreListRepository : EfRepositoryBase<BookGenreList, LibraryContext>, IBookGenreListRepository
    {
        public EfBookGenreListRepository(LibraryContext context) : base(context)
        {
        }
    }
}
