using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class BookWishListUpdateRequestModel : IUpdateModel
    {
        public BookWishListUpdateRequestModel() { }

        public BookWishListUpdateRequestModel(int id, int accountId, int bookId)
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
