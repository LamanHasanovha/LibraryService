using Core.DataAccess.Repositories;
using Entities.Concrete;
using Entities.Models.ResponseModels;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IBookRepository : IExtendedRepository<Book>
    {
        Task<List<BookResponseModel>> GetBooks(Expression<Func<Book, bool>> predicate = null);
        Task<List<Book>> GetByIds(List<int> result);
        Task<string> GetMaxMinValue();
        Task<BookResponseModel> GetRandomBook();
        Task<List<Book>> GetSameGenre(int bookId, int count);
    }
}
