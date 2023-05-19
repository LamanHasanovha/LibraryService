using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfMenuContentRepository : EfRepositoryBase<MenuContent, LibraryContext>, IMenuContentRepository
    {
        public EfMenuContentRepository(LibraryContext context) : base(context)
        {
        }
    }
}
