using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfActorRepository : EfRepositoryBase<Actor, LibraryContext>, IActorRepository
    {
        public EfActorRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<Actor> GetRandomActor()
        {
            var rand = new Random();
            int toSkip = rand.Next(1, Context.Actors.Count());
            var result = await Context.Actors.OrderBy(o => Guid.NewGuid()).Skip(toSkip).Take(1).FirstOrDefaultAsync();

            return result;
        }
    }
}
