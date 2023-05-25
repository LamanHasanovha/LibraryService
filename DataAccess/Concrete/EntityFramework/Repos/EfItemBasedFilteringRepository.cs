using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfItemBasedFilteringRepository : EfRepositoryBase<ItemBasedFiltering, LibraryContext>, IItemBasedFilteringRepository
    {
        public EfItemBasedFilteringRepository(LibraryContext context) : base(context)
        {
        }
    }
}
