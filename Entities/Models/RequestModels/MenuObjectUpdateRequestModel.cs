using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Models.RequestModels
{
    public class MenuObjectUpdateRequestModel : IUpdateModel
    {
        public MenuObjectUpdateRequestModel() { }

        public MenuObjectUpdateRequestModel(int id, string title, string description, int contentId, ProductTypes productType, int recordId)
        {
            Id = id;
            Title = title;
            Description = description;
            ContentId = contentId;
            ProductType = productType;
            RecordId = recordId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ContentId { get; set; }
        public ProductTypes ProductType { get; set; }
        public int RecordId { get; set; }
    }
}
