using Business.Recommedation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendersController : ControllerBase
    {
        private readonly IRecommenderService Service;

        public RecommendersController(IRecommenderService service)
        {
            Service = service;
        }

        [HttpGet("getmoviesbyaccount")]
        public async Task<IActionResult> GetMoviesByAccount(int accountId, int count)
        {
            return Ok(await Service.GetMoviesByAccount(accountId, count));
        }

        [HttpGet("getmovies")]
        public async Task<IActionResult> GetMovies(int movieId, int count)
        {
            return Ok(await Service.GetMovies(movieId, count));
        }

        [HttpGet("getbooksbyaccount")]
        public async Task<IActionResult> GetBooksByAccount(int accountId, int count)
        {
            return Ok(await Service.GetBooksByAccount(accountId, count));
        }

        [HttpGet("getbooks")]
        public async Task<IActionResult> GetBooks(int bookId, int count)
        {
            return Ok(await Service.GetBooks(bookId, count));
        }

        [HttpPost("trainitems")]
        public async Task<IActionResult> TrainItems()
        {
            await Service.TrainItems();
            return Ok();
        }

        [HttpPost("trainusers")]
        public async Task<IActionResult> TrainUsers()
        {
            await Service.TrainUsers();
            return Ok();
        }
    }
}
