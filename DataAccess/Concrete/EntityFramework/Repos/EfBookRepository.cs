using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfBookRepository : EfRepositoryBase<Book, LibraryContext>, IBookRepository
    {
        public EfBookRepository(LibraryContext context) : base(context)
        {

        }

        public async Task<List<BookResponseModel>> GetBooks(Expression<Func<Book, bool>> predicate = null)
        {
            var result = from b in predicate is null
                                    ? Context.Books.Include(b => b.Author).Include(b => b.Language).Include(b => b.BookGenreLists).ThenInclude(bg => bg.BookGenre)
                                    : Context.Books.Include(b => b.Author).Include(b => b.Language).Include(b => b.BookGenreLists).ThenInclude(bg => bg.BookGenre).Where(predicate)
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

            var data = await result.ToListAsync();

            return data;
        }

        public async Task<string> GetMaxMinValue()
        {
            var maxValue = await Context.Books.MaxAsync(m => m.Price);
            var minValue = await Context.Books.MinAsync(m => m.Price);

            return maxValue.ToString() + "-" + minValue.ToString();
        }

        public async Task<BookResponseModel> GetRandomBook()
        {
            var rand = new Random();
            int toSkip = rand.Next(1, Context.Movies.Count());
            var result = from b in Context.Books.OrderBy(o => Guid.NewGuid()).Skip(toSkip).Take(1)
                         .Include(b => b.Author).Include(b => b.Language).Include(b => b.BookGenreLists).ThenInclude(bg => bg.BookGenre)
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
