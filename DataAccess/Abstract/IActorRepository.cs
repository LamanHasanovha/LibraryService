using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IActorRepository : IExtendedRepository<Actor>
    {
        Task<Actor> GetRandomActor();
    }
}
