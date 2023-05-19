using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Concrete
{
    public class Cart : IEntity
    {
        public Cart() { }

        public Cart(int id, int accountId, int recordId, ProductTypes type)
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

        public Account Account { get; set; }
    }
}
