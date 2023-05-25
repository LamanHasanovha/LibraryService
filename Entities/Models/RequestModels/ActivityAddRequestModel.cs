using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Models.RequestModels
{
    public class ActivityAddRequestModel : IAddModel
    {
        public ActivityAddRequestModel() { }

        public ActivityAddRequestModel(int accountId, int recordId, ProductTypes productType)
        {
            AccountId = accountId;
            RecordId = recordId;
            ProductType = productType;
        }

        public int AccountId { get; set; }
        public int RecordId { get; set; }
        public ProductTypes ProductType { get; set; }
    }
}
