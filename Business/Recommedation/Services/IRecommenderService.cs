using Entities.Concrete;

namespace Business.Recommedation.Services
{
    public interface IRecommenderService
    {
        Task<List<Movie>> GetMoviesByAccount(int accountId, int count);
        Task<List<Movie>> GetMovies(int movieId, int count);
        Task<List<Book>> GetBooksByAccount(int accountId, int count);
        Task<List<Book>> GetBooks(int bookId, int count);
        Task TrainItems();
        Task TrainUsers();
    }
}
