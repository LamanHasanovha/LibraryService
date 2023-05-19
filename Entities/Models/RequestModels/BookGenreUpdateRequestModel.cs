using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class BookGenreUpdateRequestModel : IUpdateModel
    {
        public BookGenreUpdateRequestModel() { }

        public BookGenreUpdateRequestModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
