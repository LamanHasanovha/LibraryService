using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class BookAddRequestModel : IAddModel
    {
        public BookAddRequestModel() { }
        public BookAddRequestModel(string name, string description, int authorId, int page, int languageId, string image, decimal price)
        {
            Name = name;
            Description = description;
            AuthorId = authorId;
            Page = page;
            LanguageId = languageId;
            Image = image;
            Price = price;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int Page { get; set; }
        public int LanguageId { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}
