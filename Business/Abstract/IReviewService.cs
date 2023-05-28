using Core.Business.Abstract;
using Entities.Concrete;
using Entities.Constants;
using Entities.Models.ResponseModels;

namespace Business.Abstract
{
    public interface IReviewService : IExtendedServiceRepository<Review>
    {
        Task<ReviewResponseModel> GetByType(int recordId, RatingTypes type);
    }
}
