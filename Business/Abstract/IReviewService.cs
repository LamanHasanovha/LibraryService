using Core.Business.Abstract;
using Entities.Concrete;
using Entities.Constants;
using Entities.Models.ResponseModels;

namespace Business.Abstract
{
    public interface IReviewService : IExtendedServiceRepository<Review>
    {
        Task<Review> GetByAccount(int id, int recordId, RatingTypes type);
        Task<List<ReviewResponseModel>> GetByType(int recordId, RatingTypes type);
    }
}
