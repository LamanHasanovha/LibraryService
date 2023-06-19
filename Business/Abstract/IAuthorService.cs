using Core.Business.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAuthorService : IExtendedServiceRepository<Author>
    {
        Task<Author> GetRandomAuthor();
    }
}
