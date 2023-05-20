using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class RatingDeleteRequestModel : IDeleteModel
    {
        public RatingDeleteRequestModel() { }

        public RatingDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
