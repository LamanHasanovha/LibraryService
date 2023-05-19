using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MovieGenreManager : ManagerRepositoryBase<MovieGenre, IMovieGenreRepository>, IMovieGenreService
    {
        public MovieGenreManager(IMovieGenreRepository repository) : base(repository)
        {
            //base.SetValidator(new MovieGenreValidator());
        }
    }
}
