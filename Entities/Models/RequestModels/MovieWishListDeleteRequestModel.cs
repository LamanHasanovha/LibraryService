using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MovieWishListDeleteRequestModel : IDeleteModel
    {
        public MovieWishListDeleteRequestModel() { }

        public MovieWishListDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
