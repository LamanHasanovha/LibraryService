using Core.Entities.Abstract;

namespace Core.Entities.Models
{
    public class UserOperationClaimDeleteRequestModel : IDeleteModel
    {
        public UserOperationClaimDeleteRequestModel() { }
        public UserOperationClaimDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
