using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfUserBasedFilteringRepository : EfRepositoryBase<UserBasedFiltering, LibraryContext>, IUserBasedFilteringRepository
    {
        public EfUserBasedFilteringRepository(LibraryContext context) : base(context)
        {
        }
    }
}
