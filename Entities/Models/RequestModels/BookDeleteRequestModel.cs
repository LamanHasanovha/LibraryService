using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class BookDeleteRequestModel : IDeleteModel
    {
        public BookDeleteRequestModel() { }

        public BookDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
