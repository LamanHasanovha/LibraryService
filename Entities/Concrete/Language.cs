using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Language : IEntity
    {
        public Language() { }

        public Language(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
