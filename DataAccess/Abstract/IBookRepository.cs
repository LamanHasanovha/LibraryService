using Core.DataAccess.Repositories;
using Entities.Concrete;
using Entities.Models.ResponseModels;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IBookRepository : IExtendedRepository<Book>
    {
        Task<List<BookResponseModel>> GetBooks(Expression<Func<Book, bool>> predicate = null);
        Task<BookResponseModel> GetRandomBook();
    }
}
