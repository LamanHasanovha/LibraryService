using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BookGenreManager : ManagerRepositoryBase<BookGenre, IBookGenreRepository>, IBookGenreService
    {
        public BookGenreManager(IBookGenreRepository repository) : base(repository)
        {
            //base.SetValidator(new BookGenreValidator());
        }
    }
}
