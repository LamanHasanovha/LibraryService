using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ActorManager : ManagerRepositoryBase<Actor, IActorRepository>, IActorService
    {
        public ActorManager(IActorRepository repository) : base(repository)
        {
            //base.SetValidator(new ActorValidator());
        }
    }
}
