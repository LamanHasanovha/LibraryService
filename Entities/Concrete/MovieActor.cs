using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class MovieActor : IEntity
    {
        public MovieActor() { }

        public MovieActor(int id, int movieId, int actorId)
        {
            Id = id;
            MovieId = movieId;
            ActorId = actorId;
        }

        public int Id { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
