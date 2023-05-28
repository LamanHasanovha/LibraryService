using Core.DataAccess.Repositories;
using Entities.Concrete;
using Entities.Constants;
using Entities.Models.ResponseModels;

namespace DataAccess.Abstract
{
    public interface IReviewRepository : IExtendedRepository<Review>
    {
        Task<ReviewResponseModel> GetByType(int recordId, RatingTypes type);
    }
}
