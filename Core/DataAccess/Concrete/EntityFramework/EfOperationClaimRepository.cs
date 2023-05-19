using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework.Contexts;
using Core.DataAccess.Repositories.EntityFramework;
using Core.Entities.Concrete;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaimRepository : EfRepositoryBase<OperationClaim, CoreContext>, IOperationClaimRepository
    {
        public EfOperationClaimRepository(CoreContext context) : base(context)
        {
        }
    }
}
