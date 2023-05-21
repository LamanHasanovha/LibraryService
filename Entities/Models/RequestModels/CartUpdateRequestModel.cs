using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Models.RequestModels
{
    public class CartUpdateRequestModel : IUpdateModel
    {
        public CartUpdateRequestModel() { }

        public CartUpdateRequestModel(int id, int accountId, int recordId, ProductTypes type)
        {
            Id = id;
            AccountId = accountId;
            RecordId = recordId;
            Type = type;
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public int RecordId { get; set; }
        public ProductTypes Type { get; set; }
    }
}
