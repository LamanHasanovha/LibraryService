using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ActivityManager : ManagerRepositoryBase<Activity, IActivityRepository>, IActivityService
    {
        public ActivityManager(IActivityRepository repository) : base(repository)
        {
        }
    }
}
