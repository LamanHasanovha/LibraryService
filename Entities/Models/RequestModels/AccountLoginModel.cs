using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class AccountLoginModel : IModel
    {
        public AccountLoginModel() { }

        public AccountLoginModel(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
