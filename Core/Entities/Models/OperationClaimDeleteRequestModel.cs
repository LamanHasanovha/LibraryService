using Core.Entities.Abstract;

namespace Core.Entities.Models
{
    public class OperationClaimDeleteRequestModel : IDeleteModel
    {
        public OperationClaimDeleteRequestModel() { }

        public OperationClaimDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
