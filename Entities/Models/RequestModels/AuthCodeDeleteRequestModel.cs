using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class AuthCodeDeleteRequestModel : IDeleteModel
    {
        public AuthCodeDeleteRequestModel() { }

        public AuthCodeDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
