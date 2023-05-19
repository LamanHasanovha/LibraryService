using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MenuObjectDeleteRequestModel : IDeleteModel
    {
        public MenuObjectDeleteRequestModel() { }

        public MenuObjectDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
