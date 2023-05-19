using Core.Business.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBookGenreListService : IExtendedServiceRepository<BookGenreList>
    {
        Task<int> DeleteByBook(int id);
        Task<List<BookGenreList>> GetByBook(int id);
        Task<List<BookGenreList>> UpdateByBook(List<BookGenreList> list);
    }
}
