using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class CartDeleteRequestModel : IDeleteModel
    {
        public CartDeleteRequestModel() { }

        public CartDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
