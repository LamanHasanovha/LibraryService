using Business.Abstract;
using Business.Constants;
using Core.Business.Concrete;
using Core.CCC.Exception;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BookGenreListManager : ManagerRepositoryBase<BookGenreList, IBookGenreListRepository>, IBookGenreListService
    {
        public BookGenreListManager(IBookGenreListRepository repository) : base(repository)
        {
            //base.SetValidator(new BookGenreListValidator());
        }

        public async Task<int> DeleteByBook(int id)
        {
            var list = await Repository.GetAllAsync(l => l.BookId == id);

            foreach (var item in list)
            {
                await Repository.DeleteAsync(item);
            }

            return await Task.FromResult(list.Count);
        }

        public async Task<List<BookGenreList>> GetByBook(int id)
        {
            return await Repository.GetAllAsync(l=>l.BookId == id);
        }

        public async Task<List<BookGenreList>> UpdateByBook(List<BookGenreList> list)
        {
            if (list.Count == 0)
                return await Task.FromResult(new List<BookGenreList>());

            await DeleteByBook(list[0].BookId);
            var result = new List<BookGenreList>();
            foreach (var item in list)
            {
                result.Add(await Repository.AddAsync(item));
            }

            return result;
        }
    }
}
