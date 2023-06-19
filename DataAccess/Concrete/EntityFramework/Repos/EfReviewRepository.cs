using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Constants;
using Entities.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfReviewRepository : EfRepositoryBase<Review, LibraryContext>, IReviewRepository
    {
        public EfReviewRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<List<ReviewResponseModel>> GetByType(int recordId, RatingTypes type)
        {
            var result = from r in Context.Reviews.Where(r => r.RecordId == recordId && r.Type == type).Include(r => r.Account)
                         select new ReviewResponseModel
                         {
                             Id = r.Id,
                             Date = r.Date,
                             RecordId = recordId,
                             Type = type,
                             Text = r.Text,
                             Username = r.Account.Username
                         };

            return await result.ToListAsync();
        }
    }
}
