using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MovieFavListAddRequestModel : IAddModel
    {
        public MovieFavListAddRequestModel() { }

        public MovieFavListAddRequestModel(int accountId, int movieId)
        {
            AccountId = accountId;
            MovieId = movieId;
        }

        public int AccountId { get; set; }
        public int MovieId { get; set; }
    }
}
