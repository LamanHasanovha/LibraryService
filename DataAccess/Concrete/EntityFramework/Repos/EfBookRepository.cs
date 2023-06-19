using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Constants;
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

        public async Task<List<Book>> GetByIds(List<int> result)
        {
            return await Context.Books.Where(b => result.Contains(b.Id)).ToListAsync();
        }

        public async Task<string> GetMaxMinValue()
        {
            var maxValue = await Context.Books.MaxAsync(m => m.Price);
            var minValue = await Context.Books.MinAsync(m => m.Price);

            return maxValue.ToString() + "-" + minValue.ToString();
        }

        public async Task<List<BookResponseModel>> GetPopularBooks()
        {
            var topSellers = Context.Purchases.Where(p => p.ProductType == ProductTypes.Book).GroupBy(p => p.RecordId).Select(g => new { BookId = g.Key, TotalSales = g.Count() })
                                    .OrderByDescending(p => p.TotalSales).Where(g => g.TotalSales > 5).Take(10)
                                    .Join(Context.Books.Include(b => b.Author).Include(b => b.Language).Include(b => b.BookGenreLists).ThenInclude(bg => bg.BookGenre),
                                    b => b.BookId, book => book.Id, (b, book) => new { Book = book, b.TotalSales });

            var result = from b in Context.Books.Where(b=>topSellers.Select(s=>s.Book.Id).Contains(b.Id)).Include(b => b.Author).Include(b => b.Language).Include(b => b.BookGenreLists).ThenInclude(bg => bg.BookGenre)
                         select new BookResponseModel
                         {
                             Id = b.Id,
                             Author = b.Author.FirstName + " " + b.Author.LastName,
                             Description = b.Description,
                             Image = b.Image,
                             Language = b.Language.Name,
                             Name = b.Name,
                             Page = b.Page,
                             Price = b.Price,
                             Genres = b.BookGenres.ToList()
                         };

            var data = await result.ToListAsync();

            if(data.Count < 10)
            {
                var topRateds = Context.Ratings.Where(r => r.Type == RatingTypes.Book & r.Value > 2).GroupBy(r => r.RecordId).Select(g => new { BookId = g.Key, TotalRates = g.Count() })
                                       .OrderByDescending(r => r.TotalRates).Where(g => g.TotalRates > 5).Take(10)
                                       .Join(Context.Books.Include(b => b.Author).Include(b => b.Language).Include(b => b.BookGenreLists).ThenInclude(bg => bg.BookGenre),
                                       b => b.BookId, book => book.Id, (b, book) => new { Book = book, b.TotalRates });

                var result2 = from b in Context.Books.Where(b => topRateds.Select(s => s.Book.Id).Contains(b.Id)).Include(b => b.Author).Include(b => b.Language).Include(b => b.BookGenreLists).ThenInclude(bg => bg.BookGenre)
                              select new BookResponseModel
                              {
                                  Id = b.Id,
                                  Author = b.Author.FirstName + " " + b.Author.LastName,
                                  Description = b.Description,
                                  Image = b.Image,
                                  Language = b.Language.Name,
                                  Name = b.Name,
                                  Page = b.Page,
                                  Price = b.Price,
                                  Genres = b.BookGenres.ToList()
                              };
                data.AddRange(await result2.ToListAsync());
            }

            if(data.Count < 10)
            {
                var topVisiteds = Context.Activities.Where(a => a.ProductType == ProductTypes.Book).GroupBy(a => a.RecordId).Select(g => new { BookId = g.Key, TotalVisits = g.Count() })
                                         .OrderByDescending(a => a.TotalVisits).Where(g => g.TotalVisits > 10).Take(10)
                                         .Join(Context.Books.Include(b => b.Author).Include(b => b.Language).Include(b => b.BookGenreLists).ThenInclude(bg => bg.BookGenre),
                                         b => b.BookId, book => book.Id, (b, book) => new { Book = book, b.TotalVisits });

                var result3 = from b in Context.Books.Where(b => topVisiteds.Select(s => s.Book.Id).Contains(b.Id)).Include(b => b.Author).Include(b => b.Language).Include(b => b.BookGenreLists).ThenInclude(bg => bg.BookGenre)
                              select new BookResponseModel
                              {
                                  Id = b.Id,
                                  Author = b.Author.FirstName + " " + b.Author.LastName,
                                  Description = b.Description,
                                  Image = b.Image,
                                  Language = b.Language.Name,
                                  Name = b.Name,
                                  Page = b.Page,
                                  Price = b.Price,
                                  Genres = b.BookGenres.ToList()
                              };
                data.AddRange(await result3.ToListAsync());
            }

            return data;
        }

        public async Task<BookResponseModel> GetRandomBook()
        {
            var rand = new Random();
            int toSkip = rand.Next(1, Context.Books.Count());
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

        public async Task<List<Book>> GetSameGenre(int bookId, int count)
        {
            var genres = (await Context.BookGenreLists.Where(l => l.BookId == bookId).ToListAsync()).Select(g => g.BookGenreId);

            var books = (await Context.BookGenreLists.Where(l => genres.Contains(l.BookGenreId)).ToListAsync()).Select(g => g.BookId);

            return await Context.Books.Where(b => books.Contains(b.Id)).Take(count).ToListAsync();
        }
    }
}
