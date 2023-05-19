using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class BookGenreDeleteRequestModel : IDeleteModel
    {
        public BookGenreDeleteRequestModel() { }

        public BookGenreDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
