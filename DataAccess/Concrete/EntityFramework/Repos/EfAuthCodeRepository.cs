using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfAuthCodeRepository : EfRepositoryBase<AuthCode, LibraryContext>, IAuthCodeRepository
    {
        public EfAuthCodeRepository(LibraryContext context) : base(context)
        {
        }
    }
}
