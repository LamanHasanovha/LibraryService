using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class BookGenreAddRequestModel : IAddModel
    {
        public BookGenreAddRequestModel() { }

        public BookGenreAddRequestModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
