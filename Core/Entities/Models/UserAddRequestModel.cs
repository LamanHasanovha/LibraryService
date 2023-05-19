using Core.Entities.Abstract;

namespace Core.Entities.Models
{
    public class UserAddRequestModel : IAddModel
    {
        public UserAddRequestModel() { }

        public UserAddRequestModel(string firstName, string lastName, string email, byte[] passwordHash, byte[] passwordSalt, bool status)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Status = status;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
    }
}
