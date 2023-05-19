using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.Models.ResponseModels
{
    public class MovieResponseModel : IModel
    {
        public MovieResponseModel() { }

        public MovieResponseModel(int id, string genre, string name, double imdb, DateTime releaseDate, long time, string description, string director, string image, decimal price)
        {
            Id = id;
            Name = name;
            Imdb = imdb;
            ReleaseDate = releaseDate;
            Time = time;
            Description = description;
            Director = director;
            Image = image;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Imdb { get; set; }
        public DateTime ReleaseDate {get; set; }
        public long Time { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public List<MovieGenre> Genres { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
