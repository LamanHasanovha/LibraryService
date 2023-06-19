using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Constants;
using Entities.Models.ResponseModels;

namespace Business.Concrete
{
    public class ReviewManager : ManagerRepositoryBase<Review, IReviewRepository>, IReviewService
    {
        public ReviewManager(IReviewRepository repository) : base(repository)
        {
            //base.SetValidator(new ReviewValidator());
        }

        public async Task<Review> GetByAccount(int id, int recordId, RatingTypes type)
        {
            return await Repository.GetAsync(r => r.AccountId == id & r.RecordId == recordId & r.Type == type);
        }

        public async Task<List<ReviewResponseModel>> GetByType(int recordId, RatingTypes type)
        {
            return await Repository.GetByType(recordId, type);
        }
    }
}
