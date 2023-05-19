using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MovieGenreListAddRequestModel : IAddModel
    {
        public MovieGenreListAddRequestModel() { }

        public MovieGenreListAddRequestModel(int movieId, int movieGenreId)
        {
            MovieId = movieId;
            MovieGenreId = movieGenreId;
        }

        public int MovieId { get; set; }
        public int MovieGenreId { get; set; }
    }
}
