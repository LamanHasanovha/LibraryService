using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MenuContentDeleteRequestModel : IDeleteModel
    {
        public MenuContentDeleteRequestModel() { }

        public MenuContentDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
