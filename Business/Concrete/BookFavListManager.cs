using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Models.ResponseModels;

namespace Business.Concrete
{
    public class BookFavListManager : ManagerRepositoryBase<BookFavList, IBookFavListRepository>, IBookFavListService
    {
        public BookFavListManager(IBookFavListRepository repository) : base(repository)
        {
            //base.SetValidator(new BookFavListValidator());
        }

        public async Task<List<BookResponseModel>> GetByAccount(int id)
        {
            return await Repository.GetByAccount(id);
        }

        public async Task RemoveByAccount(int accountId, int bookId)
        {
            var result = await Repository.GetAsync(l => l.AccountId == accountId & l.BookId == bookId);

            await Repository.DeleteAsync(result);
        }
    }
}
