using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MovieActorAddRequestModel : IAddModel
    {
        public MovieActorAddRequestModel() { }

        public MovieActorAddRequestModel(int movieId, int actorId)
        {
            MovieId = movieId;
            ActorId = actorId;
        }

        public int MovieId { get; set; }
        public int ActorId { get; set; }
    }
}
