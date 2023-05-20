using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Models.RequestModels
{
    public class RatingUpdateRequestModel : IUpdateModel
    {
        public RatingUpdateRequestModel() { }

        public RatingUpdateRequestModel(int id, int accountId, int recordId, int value, RatingTypes type)
        {
            Id = id;
            AccountId = accountId;
            RecordId = recordId;
            Value = value;
            Type = type;
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public int RecordId { get; set; }
        public int Value { get; set; }
        public RatingTypes Type { get; set; }
    }
}
