using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class BookGenreListAddRequestModel : IAddModel
    {
        public BookGenreListAddRequestModel() { }

        public BookGenreListAddRequestModel(int bookId, int bookGenreId)
        {
            BookId = bookId;
            BookGenreId = bookGenreId;
        }

        public int BookId { get; set; }
        public int BookGenreId { get; set; }
    }
}
