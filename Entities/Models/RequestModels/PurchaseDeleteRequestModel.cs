using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class PurchaseDeleteRequestModel : IDeleteModel
    {
        public PurchaseDeleteRequestModel() { }

        public PurchaseDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
