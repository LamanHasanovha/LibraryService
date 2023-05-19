using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Models.ResponseModels;

namespace Business.Concrete
{
    public class BookManager : ManagerRepositoryBase<Book, IBookRepository>, IBookService
    {
        public BookManager(IBookRepository repository) : base(repository)
        {
            //base.SetValidator(new BookValidator());
        }

        public async Task<BookResponseModel> GetBookById(int id)
        {
            var data = await Repository.GetBooks(b => b.Id == id);
            return data.FirstOrDefault();
        }

        public async Task<List<BookResponseModel>> GetBooks()
        {
            return await Repository.GetBooks();
        }

        public async Task<List<Book>> GetByAuthor(int id)
        {
            return await Repository.GetAllAsync(b=>b.AuthorId == id);
        }

        public async Task<BookResponseModel> GetRandomBook()
        {
            return await Repository.GetRandomBook();
        }
    }
}
