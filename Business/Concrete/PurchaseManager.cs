using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PurchaseManager : ManagerRepositoryBase<Purchase, IPurchaseRepository>, IPurchaseService
    {
        public PurchaseManager(IPurchaseRepository repository) : base(repository)
        {
        }
    }
}
