using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieWishListsController : BaseController<IMovieWishListService, MovieWishList, MovieWishListAddRequestModel, MovieWishListUpdateRequestModel, MovieWishListDeleteRequestModel>
    {
        public MovieWishListsController(IMovieWishListService service) : base(service)
        {
        }

        [HttpGet("getbyaccount")]
        public async Task<IActionResult> GetByAccount(int id)
        {
            return Ok(await Service.GetByAccount(id));
        }

        [HttpPost("removebyaccount")]
        public async Task<IActionResult> RemoveByAccount(int accountId, int movieId)
        {
            await Service.RemoveByAccount(accountId, movieId);
            return Ok();
        }
    }
}
