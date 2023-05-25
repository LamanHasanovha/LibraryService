using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class ActivityDeleteRequestModel : IDeleteModel
    {
        public ActivityDeleteRequestModel() { }

        public ActivityDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
