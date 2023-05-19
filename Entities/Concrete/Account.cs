using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Account : IEntity
    {
        public Account() { }

        public Account(int id, string firstName, string lastName, string username, string email, byte[] passwordHash, byte[] passwordSalt, DateTime lastLoginDate, bool status)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            LastLoginDate = lastLoginDate;
            Status = status;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool Status { get; set; }

        public ICollection<BookFavList> BookFavLists { get; set; }
        public ICollection<BookWishList> BookWishLists { get; set; }
        public ICollection<MovieFavList> MovieFavLists { get; set; }
        public ICollection<MovieWishList> MovieWishLists { get; set; }
        public ICollection<Cart> Carts { get; set; }

    }
}
