using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfMovieActorRepository : EfRepositoryBase<MovieActor, LibraryContext>, IMovieActorRepository
    {
        public EfMovieActorRepository(LibraryContext context) : base(context)
        {
        }
    }
}
