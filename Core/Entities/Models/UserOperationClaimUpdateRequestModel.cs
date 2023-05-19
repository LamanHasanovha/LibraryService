using Core.Entities.Abstract;

namespace Core.Entities.Models
{
    public class UserOperationClaimUpdateRequestModel : IUpdateModel
    {
        public UserOperationClaimUpdateRequestModel() { }

        public UserOperationClaimUpdateRequestModel(int id, int userId, int operationClaimId)
        {
            Id = id;
            UserId = userId;
            OperationClaimId = operationClaimId;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
