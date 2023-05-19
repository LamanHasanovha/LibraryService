using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class BookWishList : IEntity
    {
        public BookWishList() { }

        public BookWishList(int id, int accountId, int bookId)
        {
            Id = id;
            AccountId = accountId;
            BookId = bookId;
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public int BookId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Book Book { get; set; }
    }
}
