using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfAccountRepository : EfRepositoryBase<Account, LibraryContext>, IAccountRepository
    {
        public EfAccountRepository(LibraryContext context) : base(context)
        {
        }
    }
}
