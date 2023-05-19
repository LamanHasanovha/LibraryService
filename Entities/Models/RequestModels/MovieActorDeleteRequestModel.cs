using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MovieActorDeleteRequestModel : IDeleteModel
    {
        public MovieActorDeleteRequestModel() { }

        public MovieActorDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
