using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class MovieGenre : IEntity
    {
        public MovieGenre() { }

        public MovieGenre(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<MovieGenreList> MovieGenreLists { get; set; }
    }
}
