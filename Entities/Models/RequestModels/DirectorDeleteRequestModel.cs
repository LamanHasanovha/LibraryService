using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class DirectorDeleteRequestModel : IDeleteModel
    {
        public DirectorDeleteRequestModel() { }

        public DirectorDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
