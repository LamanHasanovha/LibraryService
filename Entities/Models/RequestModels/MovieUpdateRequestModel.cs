using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MovieUpdateRequestModel : IUpdateModel
    {
        public MovieUpdateRequestModel() { }

        public MovieUpdateRequestModel(int id, string name, double imdb, DateTime releaseDate, long time, string description, int directorId, string image, decimal price)
        {
            Id = id;
            Name = name;
            Imdb = imdb;
            ReleaseDate = releaseDate;
            Time = time;
            Description = description;
            DirectorId = directorId;
            Image = image;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Imdb { get; set; }
        public DateTime ReleaseDate { get; set; }
        public long Time { get; set; }
        public string Description { get; set; }
        public int DirectorId { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}
