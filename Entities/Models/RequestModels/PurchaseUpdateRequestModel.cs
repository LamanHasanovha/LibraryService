using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Models.RequestModels
{
    public class PurchaseUpdateRequestModel : IUpdateModel
    {
        public PurchaseUpdateRequestModel() { }

        public PurchaseUpdateRequestModel(int id, int accountId, int recordId, ProductTypes productType)
        {
            Id = id;
            AccountId = accountId;
            RecordId = recordId;
            ProductType = productType;
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public int RecordId { get; set; }
        public ProductTypes ProductType { get; set; }
    }
}
