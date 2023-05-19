using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class MovieGenreUpdateRequestModel : IUpdateModel
    {
        public MovieGenreUpdateRequestModel() { }

        public MovieGenreUpdateRequestModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
