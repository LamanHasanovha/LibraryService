using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class BookGenreList : IEntity
    {
        public BookGenreList() { }

        public BookGenreList(int id, int bookId, int bookGenreId)
        {
            Id = id;
            BookId = bookId;
            BookGenreId = bookGenreId;
        }

        public int Id { get; set; }
        public int BookId { get; set; }
        public int BookGenreId { get; set; }

        public virtual Book Book { get; set; }
        public virtual BookGenre BookGenre { get; set; }
    }
}
