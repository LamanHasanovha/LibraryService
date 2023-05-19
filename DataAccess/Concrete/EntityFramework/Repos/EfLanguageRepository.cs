using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfLanguageRepository : EfRepositoryBase<Language, LibraryContext>, ILanguageRepository
    {
        public EfLanguageRepository(LibraryContext context) : base(context)
        {
        }
    }
}
