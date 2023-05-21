using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ReviewManager : ManagerRepositoryBase<Review, IReviewRepository>, IReviewService
    {
        public ReviewManager(IReviewRepository repository) : base(repository)
        {
            //base.SetValidator(new ReviewValidator());
        }
    }
}
