using Core.Entities.Abstract;

namespace Core.Entities.Models
{
    public class UserUpdateRequestModel : IUpdateModel
    {
        public UserUpdateRequestModel() { }

        public UserUpdateRequestModel(int id, string firstName, string lastName, string email, byte[] passwordHash, byte[] passwordSalt, bool status)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Status = status;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
    }
}
