using Core.Entities.Abstract;

namespace Core.Entities.Models
{
    public class OperationClaimAddRequestModel : IAddModel
    {
        public OperationClaimAddRequestModel() { }

        public OperationClaimAddRequestModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

    }
}
