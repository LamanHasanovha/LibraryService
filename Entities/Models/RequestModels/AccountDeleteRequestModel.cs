using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class AccountDeleteRequestModel : IDeleteModel
    {
        public AccountDeleteRequestModel() { }

        public AccountDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
