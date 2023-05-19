using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class ChartDeleteRequestModel : IDeleteModel
    {
        public ChartDeleteRequestModel() { }

        public ChartDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
