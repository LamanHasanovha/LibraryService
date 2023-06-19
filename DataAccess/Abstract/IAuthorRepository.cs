using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IAuthorRepository : IExtendedRepository<Author>
    {
        Task<Author> GetRandomAuthor();
    }
}
