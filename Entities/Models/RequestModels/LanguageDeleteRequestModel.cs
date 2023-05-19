using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class LanguageDeleteRequestModel : IDeleteModel
    {
        public LanguageDeleteRequestModel() { }

        public LanguageDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
