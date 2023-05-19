using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Concrete
{
    public class MenuContent : IEntity
    {
        public MenuContent() { }

        public MenuContent(int id, string? title, string? description, ContentTypes contentType, int priority)
        {
            Id = id;
            Title = title;
            Description = description;
            ContentType = contentType;
            Priority = priority;
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ContentTypes ContentType { get; set; }
        public int Priority { get; set; }
    }
}
