using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfMenuObjectRepository : EfRepositoryBase<MenuObject, LibraryContext>, IMenuObjectRepository
    {
        public EfMenuObjectRepository(LibraryContext context) : base(context)
        {
        }
    }
}
