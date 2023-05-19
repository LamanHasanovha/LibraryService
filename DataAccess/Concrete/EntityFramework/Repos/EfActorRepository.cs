using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfActorRepository : EfRepositoryBase<Actor, LibraryContext>, IActorRepository
    {
        public EfActorRepository(LibraryContext context) : base(context)
        {
        }
    }
}
