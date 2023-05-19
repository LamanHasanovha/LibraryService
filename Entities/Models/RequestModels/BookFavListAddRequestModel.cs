using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class BookFavListAddRequestModel : IAddModel
    {
        public BookFavListAddRequestModel() { }

        public BookFavListAddRequestModel(int accountId, int bookId)
        {
            AccountId = accountId;
            BookId = bookId;
        }

        public int AccountId { get; set; }
        public int BookId { get; set; }
    }
}
