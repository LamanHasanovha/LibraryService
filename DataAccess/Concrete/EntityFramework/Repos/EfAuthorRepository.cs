using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfAuthorRepository : EfRepositoryBase<Author, LibraryContext>, IAuthorRepository
    {
        public EfAuthorRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<Author> GetRandomAuthor()
        {
            var rand = new Random();
            int toSkip = rand.Next(1, Context.Authors.Count());
            var result = await Context.Authors.OrderBy(o => Guid.NewGuid()).Skip(toSkip).Take(1).FirstOrDefaultAsync();

            return result;
        }
    }
}
