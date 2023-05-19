using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class MovieGenreList : IEntity
    {
        public MovieGenreList() { }

        public MovieGenreList(int id, int movieId, int movieGenreId)
        {
            Id = id;
            MovieId = movieId;
            MovieGenreId = movieGenreId;
        }

        public int Id { get; set; }
        public int MovieId { get; set; }
        public int MovieGenreId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual MovieGenre MovieGenre { get; set; }
    }
}
