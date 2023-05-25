using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfActivityRepository : EfRepositoryBase<Activity, LibraryContext>, IActivityRepository
    {
        public EfActivityRepository(LibraryContext context) : base(context)
        {
        }
    }
}
