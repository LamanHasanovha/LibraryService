using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class AccountUpdateRequestModel : IUpdateModel
    {
        public AccountUpdateRequestModel() { }

        public AccountUpdateRequestModel(int id, string firstName, string lastName, string username, string email, DateTime lastLoginDate, bool status, byte[] passwordHash, byte[] passwordSalt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            LastLoginDate = lastLoginDate;
            Status = status;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
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
    }
}
