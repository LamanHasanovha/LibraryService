using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.Models.ResponseModels
{
    public class BookResponseModel : IModel
    {
        public BookResponseModel() { }

        public BookResponseModel(int id, string name, string description, string author, int page, string language, string image, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Author = author;
            Page = page;
            Language = language;
            Image = image;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Page { get; set; }
        public string Language { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public List<BookGenre> Genres { get; set; }
    }
}
