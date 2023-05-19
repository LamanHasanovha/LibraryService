using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfDirectorRepository : EfRepositoryBase<Director, LibraryContext>, IDirectorRepository
    {
        public EfDirectorRepository(LibraryContext context) : base(context)
        {
        }
    }
}
