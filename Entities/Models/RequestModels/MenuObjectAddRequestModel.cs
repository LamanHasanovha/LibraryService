using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Models.RequestModels
{
    public class MenuObjectAddRequestModel : IAddModel
    {
        public MenuObjectAddRequestModel() { }

        public MenuObjectAddRequestModel(string title, string description, int contentId, ProductTypes productType, int recordId)
        {
            Title = title;
            Description = description;
            ContentId = contentId;
            ProductType = productType;
            RecordId = recordId;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int ContentId { get; set; }
        public ProductTypes ProductType { get; set; }
        public int RecordId { get; set; }
    }
}
