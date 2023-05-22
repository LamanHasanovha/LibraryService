using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGenreListsController : BaseController<IMovieGenreListService, MovieGenreList, MovieGenreListAddRequestModel, MovieGenreListUpdateRequestModel, MovieGenreListDeleteRequestModel>
    {
        public MovieGenreListsController(IMovieGenreListService service) : base(service)
        {
        }

        [HttpPost("updatebymovie")]
        public async Task<IActionResult> UpdateByMovie(List<MovieGenreListUpdateRequestModel> list)
        {
            return Ok(await Service.UpdateByMovie(list));
        }

        [HttpPost("deletebymovie")]
        public async Task<IActionResult> DeleteByMovie(int id)
        {
            return Ok(await Service.DeleteByMovie(id));
        }

        [HttpGet("getbymovie")]
        public async Task<IActionResult> GetByMovie(int id)
        {
            return Ok(await Service.GetByMovie(id));
        }
    }
}
