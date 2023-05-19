using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class LanguageUpdateRequestModel : IUpdateModel
    {
        public LanguageUpdateRequestModel() { }

        public LanguageUpdateRequestModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
