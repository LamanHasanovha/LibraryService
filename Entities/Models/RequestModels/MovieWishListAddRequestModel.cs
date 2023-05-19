using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MovieWishListAddRequestModel : IAddModel
    {
        public MovieWishListAddRequestModel() { }

        public MovieWishListAddRequestModel(int accountId, int movieId)
        {
            AccountId = accountId;
            MovieId = movieId;
        }

        public int AccountId { get; set; }
        public int MovieId { get; set; }
    }
}
