using Core.Business.Abstract;
using Entities.Concrete;
using Entities.Constants;

namespace Business.Abstract
{
    public interface IRatingService : IExtendedServiceRepository<Rating>
    {
        Task<List<Rating>> GetByRecord(int recordId, RatingTypes type);
        Task SaveRating(Rating rating);
    }
}
