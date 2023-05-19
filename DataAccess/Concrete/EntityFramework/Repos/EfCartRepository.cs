using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Constants;
using Entities.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfCartRepository : EfRepositoryBase<Cart, LibraryContext>, ICartRepository
    {
        public EfCartRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<List<CartResponseModel>> GetByAccount(int id)
        {
            var data = await Context.Carts.Where(c => c.AccountId == id).ToListAsync();

            var result = new List<CartResponseModel>();

            foreach (var cart in data)
            {
                var model = new CartResponseModel
                {
                    Id = cart.Id,
                    ProductType = cart.Type,
                    RecordId = cart.RecordId
                };

                switch (cart.Type)
                {
                    case ProductTypes.Book:
                        var book = await Context.Books.Where(b=>b.Id == cart.RecordId).FirstOrDefaultAsync();
                        model.Name = book.Name;
                        model.Price = book.Price;
                        model.Image = book.Image;
                        break;
                    case ProductTypes.Movie:
                        var movie = await Context.Movies.Where(b => b.Id == cart.RecordId).FirstOrDefaultAsync();
                        model.Name = movie.Name;
                        model.Price = movie.Price;
                        model.Image = movie.Image;
                        break;
                    default:
                        break;
                }
                result.Add(model);
            }

            return result;
        }
    }
}
