using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Models.RequestModels
{
    public class MenuContentAddRequestModel : IAddModel
    {
        public MenuContentAddRequestModel() { }

        public MenuContentAddRequestModel(string? title, string? description, ContentTypes contentType, int priority)
        {
            Title = title;
            Description = description;
            ContentType = contentType;
            Priority = priority;
        }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public ContentTypes ContentType { get; set; }
        public int Priority { get; set; }
    }
}
