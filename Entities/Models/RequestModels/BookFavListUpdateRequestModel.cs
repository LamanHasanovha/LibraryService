using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class BookFavListUpdateRequestModel : IUpdateModel
    {
        public BookFavListUpdateRequestModel() { }

        public BookFavListUpdateRequestModel(int id, int accountId, int bookId)
        {
            Id = id;
            AccountId = accountId;
            BookId = bookId;
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public int BookId { get; set; }
    }
}
