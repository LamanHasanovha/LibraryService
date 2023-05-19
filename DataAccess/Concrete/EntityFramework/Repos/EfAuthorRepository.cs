using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfAuthorRepository : EfRepositoryBase<Author, LibraryContext>, IAuthorRepository
    {
        public EfAuthorRepository(LibraryContext context) : base(context)
        {
        }
    }
}
