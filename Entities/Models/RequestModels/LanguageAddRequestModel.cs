using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class LanguageAddRequestModel : IAddModel
    {
        public LanguageAddRequestModel() { }

        public LanguageAddRequestModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
