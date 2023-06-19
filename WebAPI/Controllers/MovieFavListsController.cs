using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieFavListsController : BaseController<IMovieFavListService, MovieFavList, MovieFavListAddRequestModel, MovieFavListUpdateRequestModel, MovieFavListDeleteRequestModel>
    {
        public MovieFavListsController(IMovieFavListService service) : base(service)
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
