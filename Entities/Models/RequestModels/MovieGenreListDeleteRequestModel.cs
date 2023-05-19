using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MovieGenreListDeleteRequestModel : IDeleteModel
    {
        public MovieGenreListDeleteRequestModel() { }

        public MovieGenreListDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
