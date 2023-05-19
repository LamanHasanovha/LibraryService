using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MovieFavListUpdateRequestModel : IUpdateModel
    {
        public MovieFavListUpdateRequestModel() { }

        public MovieFavListUpdateRequestModel(int id, int accountId, int movieId)
        {
            Id = id;
            AccountId = accountId;
            MovieId = movieId;
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public int MovieId { get; set; }
    }
}
