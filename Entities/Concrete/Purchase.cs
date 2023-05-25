using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Concrete
{
    public class Purchase : IEntity
    {
        public Purchase() { }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public int RecordId { get; set; }
        public ProductTypes ProductType { get; set; }
    }
}
