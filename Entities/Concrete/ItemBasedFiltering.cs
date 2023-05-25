using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Concrete
{
    public class ItemBasedFiltering : IEntity
    {
        public ItemBasedFiltering() { }

        public ItemBasedFiltering(int id, int itemOneId, int itemTwoId, double similarity, ProductTypes itemType)
        {
            Id = id;
            ItemOneId = itemOneId;
            ItemTwoId = itemTwoId;
            Similarity = similarity;
            ItemType = itemType;
        }

        public int Id { get; set; }
        public int ItemOneId { get; set; }
        public int ItemTwoId { get; set; }
        public double Similarity { get; set; }
        public ProductTypes ItemType { get; set; }
    }
}
