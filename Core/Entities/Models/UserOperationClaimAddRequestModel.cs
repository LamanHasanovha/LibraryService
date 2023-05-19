using Core.Entities.Abstract;

namespace Core.Entities.Models
{
    public class UserOperationClaimAddRequestModel : IAddModel
    {
        public UserOperationClaimAddRequestModel() { }

        public UserOperationClaimAddRequestModel(int userId, int operationClaimId)
        {
            UserId = userId;
            OperationClaimId = operationClaimId;
        }

        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
