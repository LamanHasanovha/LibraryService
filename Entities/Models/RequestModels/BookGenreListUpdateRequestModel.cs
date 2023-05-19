using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class BookGenreListUpdateRequestModel : IUpdateModel
    {
        public BookGenreListUpdateRequestModel() { }

        public BookGenreListUpdateRequestModel(int id, int bookId, int bookGenreId)
        {
            Id = id;
            BookId = bookId;
            BookGenreId = bookGenreId;
        }

        public int Id { get; set; }
        public int BookId { get; set; }
        public int BookGenreId { get; set; }
    }
}
