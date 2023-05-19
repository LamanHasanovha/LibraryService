using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Models.ResponseModels
{
    public class CartResponseModel : IModel
    {
        public CartResponseModel() { }

        public CartResponseModel(int id, string name, decimal price, string image, ProductTypes productType, int recordId)
        {
            Id = id;
            Name = name;
            Price = price;
            Image = image;
            ProductType = productType;
            RecordId = recordId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public ProductTypes ProductType { get; set; }
        public int RecordId { get; set; }
    }
}
