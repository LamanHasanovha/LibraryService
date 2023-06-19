using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Concrete
{
    public class Rating : IEntity
    {
        public Rating() { }

        public Rating(int id, int accountId, int recordId, int value, RatingTypes type)
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
        public double Value { get; set; }
        public RatingTypes Type { get; set; }

        //public Account Account { get; set; }
    }
}
