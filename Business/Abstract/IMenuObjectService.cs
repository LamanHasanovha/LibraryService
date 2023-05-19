using Core.Business.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMenuObjectService : IExtendedServiceRepository<MenuObject>
    {
        Task<List<MenuObject>> GetByContent(int id);
    }
}
