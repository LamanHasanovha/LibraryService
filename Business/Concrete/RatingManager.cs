using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Constants;

namespace Business.Concrete
{
    public class RatingManager : ManagerRepositoryBase<Rating, IRatingRepository>, IRatingService
    {
        public RatingManager(IRatingRepository repository) : base(repository)
        {
        }

        public Task<List<Rating>> GetByRecord(int recordId, RatingTypes type)
        {
            return Repository.GetAllAsync(r => r.RecordId == recordId & r.Type == type);
        }

        public async Task SaveRating(Rating rating)
        {
            var result = await Repository.GetAsync(r => r.AccountId == rating.AccountId & r.Type == rating.Type);

            if (result is null)
            {
                await Repository.AddAsync(new Rating
                {
                    AccountId = rating.AccountId,
                    RecordId = rating.RecordId,
                    Type = rating.Type,
                    Value = rating.Value
                });
                return;
            }

            if (result.Value == 0)
            {
                await Repository.DeleteAsync(result);
                return;
            }

            await Repository.UpdateAsync(result);
        }
    }
}
