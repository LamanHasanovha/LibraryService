using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class AccountRegisterModel : IModel
    {
        public AccountRegisterModel() { }

        public AccountRegisterModel(string firstName, string lastName, string username, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
