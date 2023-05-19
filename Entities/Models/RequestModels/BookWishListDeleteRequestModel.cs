using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class BookWishListDeleteRequestModel : IDeleteModel
    {
        public BookWishListDeleteRequestModel() { }

        public BookWishListDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
