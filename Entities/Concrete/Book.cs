using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Book : IEntity
    {
        public Book() { }

        public Book(int id, string name, string description, int authorId, int page, int languageId, string image, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            AuthorId = authorId;
            Page = page;
            LanguageId = languageId;
            Image = image;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int Page { get; set; }
        public int LanguageId { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }

        public virtual Author Author { get; set; }
        public virtual Language Language { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
        public virtual ICollection<BookGenreList> BookGenreLists { get; set; }
    }
}
