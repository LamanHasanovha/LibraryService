using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Models.RequestModels
{
    public class RatingAddRequestModel : IAddModel
    {
        public RatingAddRequestModel() { }

        public RatingAddRequestModel(int accountId, int recordId, int value, RatingTypes type)
        {
            AccountId = accountId;
            RecordId = recordId;
            Value = value;
            Type = type;
        }

        public int AccountId { get; set; }
        public int RecordId { get; set; }
        public int Value { get; set; }
        public RatingTypes Type { get; set; }
    }
}
