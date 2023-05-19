using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class BookWishListAddRequestModel : IAddModel
    {
        public BookWishListAddRequestModel() { }

        public BookWishListAddRequestModel(int accountId, int bookId)
        {
            AccountId = accountId;
            BookId = bookId;
        }

        public int AccountId { get; set; }
        public int BookId { get; set; }
    }
}
