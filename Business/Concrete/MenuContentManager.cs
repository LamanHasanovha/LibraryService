using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MenuContentManager : ManagerRepositoryBase<MenuContent, IMenuContentRepository>, IMenuContentService
    {
        public MenuContentManager(IMenuContentRepository repository) : base(repository)
        {
            //base.SetValidator(new MenuContentValidator());
        }
    }
}
