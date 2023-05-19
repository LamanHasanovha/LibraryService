using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MovieActorUpdateRequestModel : IUpdateModel
    {
        public MovieActorUpdateRequestModel() { }

        public MovieActorUpdateRequestModel(int id, int movieId, int actorId)
        {
            Id = id;
            MovieId = movieId;
            ActorId = actorId;
        }

        public int Id { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }
    }
}
