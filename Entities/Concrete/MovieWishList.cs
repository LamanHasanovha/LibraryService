using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class MovieWishList : IEntity
    {
        public MovieWishList() { }

        public MovieWishList(int id, int accountId, int movieId)
        {
            Id = id;
            AccountId = accountId;
            MovieId = movieId;
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public int MovieId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
