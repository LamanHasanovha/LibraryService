using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MovieGenreAddRequestModel : IAddModel
    {
        public MovieGenreAddRequestModel() { }

        public MovieGenreAddRequestModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
