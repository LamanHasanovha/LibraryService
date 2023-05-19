using Core.Entities.Abstract;

namespace Core.Entities.Models
{
    public class UserDeleteRequestModel : IDeleteModel
    {
        public UserDeleteRequestModel() { }

        public UserDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
