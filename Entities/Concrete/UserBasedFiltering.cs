using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class UserBasedFiltering : IEntity
    {
        public UserBasedFiltering() { }

        public int Id { get; set; }
        public int UserOneId { get; set; }
        public int UserTwoId { get; set; }
        public double SimilarityForBook { get; set; }
        public double SimilarityForMovie { get; set; }
    }
}
