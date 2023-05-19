using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MovieGenreDeleteRequestModel : IDeleteModel
    {
        public MovieGenreDeleteRequestModel() { }

        public MovieGenreDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
