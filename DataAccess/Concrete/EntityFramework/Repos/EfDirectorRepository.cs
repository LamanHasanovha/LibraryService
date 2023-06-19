using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfDirectorRepository : EfRepositoryBase<Director, LibraryContext>, IDirectorRepository
    {
        public EfDirectorRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<Director> GetRandomDirector()
        {
            var rand = new Random();
            int toSkip = rand.Next(1, Context.Directors.Count());
            var result = await Context.Directors.OrderBy(o => Guid.NewGuid()).Skip(toSkip).Take(1).FirstOrDefaultAsync();

            return result;
        }
    }
}
