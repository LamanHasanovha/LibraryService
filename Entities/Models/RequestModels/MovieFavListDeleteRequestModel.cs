using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MovieFavListDeleteRequestModel : IDeleteModel
    {
        public MovieFavListDeleteRequestModel() { }

        public MovieFavListDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
