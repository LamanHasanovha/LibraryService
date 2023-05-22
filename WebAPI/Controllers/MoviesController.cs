using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : BaseController<IMovieService, Movie, MovieAddRequestModel, MovieUpdateRequestModel, MovieDeleteRequestModel>
    {
        public MoviesController(IMovieService service) : base(service)
        {

        }

        [HttpGet("getmovies")]
        public async Task<IActionResult> GetMovies() 
        {
            return Ok(await Service.GetMovies());
        }

        [HttpGet("getrandommovie")]
        public async Task<IActionResult> GetRandomMovie()
        {
            return Ok(await Service.GetRandomMovie());
        }

        [HttpGet("getbyactor")]
        public async Task<IActionResult> GetByActor(int id)
        {
            return Ok(await Service.GetByActor(id));
        }

        [HttpGet("getbydirector")]
        public async Task<IActionResult> GetByDirector(int id)
        {
            return Ok(await Service.GetByDirector(id));
        }

        [HttpGet("getmoviebyid")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            return Ok(await Service.GetMovieById(id));
        }

        [HttpGet("getmaxminvalue")]
        public async Task<IActionResult> GetMaxMinValue()
        {
            return Ok(await Service.GetMaxMinValue());
        }
    }
}
