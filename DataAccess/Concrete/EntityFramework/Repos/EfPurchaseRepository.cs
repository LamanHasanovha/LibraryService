using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfPurchaseRepository : EfRepositoryBase<Purchase, LibraryContext>, IPurchaseRepository
    {
        public EfPurchaseRepository(LibraryContext context) : base(context)
        {
        }
    }
}
