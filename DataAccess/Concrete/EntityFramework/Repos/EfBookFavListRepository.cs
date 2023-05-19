using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfBookFavListRepository : EfRepositoryBase<BookFavList, LibraryContext>, IBookFavListRepository
    {
        public EfBookFavListRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<List<BookResponseModel>> GetByAccount(int id)
        {
            var query = from a in Context.Accounts.Include(a=>a.BookFavLists).ThenInclude(l=>l.Book).Where(a=>a.Id == id)
                        select a.BookFavLists.Select(l=>l.Book);

            var data = await query.FirstOrDefaultAsync();

            var result = new List<BookResponseModel>();

            foreach (var item in data)
            {
                result.Add(await GetBook(item.Id));
            }

            return result;
        }

        private async Task<BookResponseModel> GetBook(int id)
        {
            var result = from b in Context.Books.Include(b => b.Author).Include(b => b.Language).Include(b => b.BookGenreLists).ThenInclude(bg => bg.BookGenre).Where(b => b.Id == id)
                         select new BookResponseModel
                         {
                             Id = b.Id,
                             Name = b.Name,
                             Description = b.Description,
                             Page = b.Page,
                             Image = b.Image,
                             Price = b.Price,
                             Author = b.Author.FirstName + " " + b.Author.LastName,
                             Language = b.Language.Name,
                             Genres = b.BookGenreLists.Select(bg => bg.BookGenre).ToList()
                         };

            var data = await result.FirstOrDefaultAsync();

            return data;
        }
    }
}
