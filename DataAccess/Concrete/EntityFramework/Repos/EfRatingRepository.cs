using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfRatingRepository : EfRepositoryBase<Rating, LibraryContext>, IRatingRepository
    {
        public EfRatingRepository(LibraryContext context) : base(context)
        {
        }
    }
}
