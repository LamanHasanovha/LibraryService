using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MovieGenreListUpdateRequestModel : IUpdateModel
    {
        public MovieGenreListUpdateRequestModel() { }

        public MovieGenreListUpdateRequestModel(int id, int movieId, int movieGenreId)
        {
            Id = id;
            MovieId = movieId;
            MovieGenreId = movieGenreId;
        }

        public int Id { get; set; }
        public int MovieId { get; set; }
        public int MovieGenreId { get; set; }
    }
}
