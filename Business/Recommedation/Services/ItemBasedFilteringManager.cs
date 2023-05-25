using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Recommedation.Services
{
    public class ItemBasedFilteringManager : ManagerRepositoryBase<ItemBasedFiltering, IItemBasedFilteringRepository>, IItemBasedFilteringService
    {
        public ItemBasedFilteringManager(IItemBasedFilteringRepository repository) : base(repository)
        {
        }
    }
}
