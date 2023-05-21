using Entities.Constants;

namespace Entities.Models.ResponseModels
{
    public class ReviewResponseModel
    {
        public ReviewResponseModel() { }

        public ReviewResponseModel(int id, string username, DateTime date, string text, int recordId, RatingTypes type)
        {
            Id = id;
            Username = username;
            Date = date;
            Text = text;
            RecordId = recordId;
            Type = type;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int RecordId { get; set; }
        public RatingTypes Type { get; set; }
    }
}
