using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class AuthorDeleteRequestModel : IDeleteModel
    {
        public AuthorDeleteRequestModel() { }

        public AuthorDeleteRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
