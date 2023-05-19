using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class BookGenreListDeleteRequestModel : IDeleteModel
    {
        public BookGenreListDeleteRequestModel() { }
        public BookGenreListDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
