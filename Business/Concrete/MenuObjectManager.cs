using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MenuObjectManager : ManagerRepositoryBase<MenuObject, IMenuObjectRepository>, IMenuObjectService
    {
        public MenuObjectManager(IMenuObjectRepository repository) : base(repository)
        {
            //base.SetValidator(new MenuObjectValidator());
        }

        public async Task<List<MenuObject>> GetByContent(int id)
        {
            return await Repository.GetAllAsync(c => c.ContentId == id);
        }
    }
}
