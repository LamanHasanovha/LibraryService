using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class BookFavListDeleteRequestModel : IDeleteModel
    {
        public BookFavListDeleteRequestModel() { }

        public BookFavListDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
