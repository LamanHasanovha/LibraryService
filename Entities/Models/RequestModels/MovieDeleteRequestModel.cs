using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MovieDeleteRequestModel : IDeleteModel
    {
        public MovieDeleteRequestModel() { }

        public MovieDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
