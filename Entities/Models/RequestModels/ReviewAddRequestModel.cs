using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Models.RequestModels
{
    public class ReviewAddRequestModel : IAddModel
    {
        public ReviewAddRequestModel() { }

        public ReviewAddRequestModel(int accountId, DateTime date, string text, int recordId, RatingTypes type)
        {
            AccountId = accountId;
            Date = date;
            Text = text;
            RecordId = recordId;
            Type = type;
        }

        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int RecordId { get; set; }
        public RatingTypes Type { get; set; }
    }
}
