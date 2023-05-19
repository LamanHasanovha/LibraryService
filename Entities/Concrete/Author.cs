using Core.Entities.Abstract;
using Entities.Constants;

namespace Entities.Concrete
{
    public class Author : IEntity
    {
        public Author() { }

        public Author(int id, string firstName, string lastName, string description, Gender gender, string image, DateTime birthDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            Gender = gender;
            Image = image;
            BirthDate = birthDate;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public Gender Gender { get; set; }
        public string Image { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
