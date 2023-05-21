using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Models.RequestModels
{
    public class CartAddRequestModel : IAddModel
    {
        public CartAddRequestModel() { }

        public CartAddRequestModel(int accountId, int recordId, ProductTypes type)
        {
            AccountId = accountId;
            RecordId = recordId;
            Type = type;
        }

        public int AccountId { get; set; }
        public int RecordId { get; set; }
        public ProductTypes Type { get; set; }
    }
}
