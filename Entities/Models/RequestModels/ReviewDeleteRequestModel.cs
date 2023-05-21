using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class ReviewDeleteRequestModel : IDeleteModel
    {
        public ReviewDeleteRequestModel() { }

        public ReviewDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
