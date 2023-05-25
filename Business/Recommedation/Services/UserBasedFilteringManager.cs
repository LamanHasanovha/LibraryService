using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Recommedation.Services
{
    public class UserBasedFilteringManager : ManagerRepositoryBase<UserBasedFiltering, IUserBasedFilteringRepository>, IUserBasedFilteringService
    {
        public UserBasedFilteringManager(IUserBasedFilteringRepository repository) : base(repository)
        {
        }
    }
}
