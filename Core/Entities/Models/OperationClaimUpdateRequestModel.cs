using Core.Entities.Abstract;

namespace Core.Entities.Models
{
    public class OperationClaimUpdateRequestModel : IUpdateModel
    {
        public OperationClaimUpdateRequestModel() { }

        public OperationClaimUpdateRequestModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
