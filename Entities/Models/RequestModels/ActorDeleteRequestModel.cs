using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class ActorDeleteRequestModel : IDeleteModel
    {
        public ActorDeleteRequestModel() { }

        public ActorDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
