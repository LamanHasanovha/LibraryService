using Core.Business.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IActorService : IExtendedServiceRepository<Actor>
    {
        Task<Actor> GetRandomActor();
    }
}
