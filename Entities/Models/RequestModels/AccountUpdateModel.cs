using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class AccountUpdateModel : IModel
    {
        public AccountUpdateModel() { }

        public AccountUpdateModel(int id, string firstName, string lastName, string username, string email, string password, bool status)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
            Status = status;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
