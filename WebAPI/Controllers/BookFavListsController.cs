using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookFavListsController : BaseController<IBookFavListService, BookFavList, BookFavListAddRequestModel, BookFavListUpdateRequestModel, BookFavListDeleteRequestModel>
    {
        public BookFavListsController(IBookFavListService service) : base(service)
        {
        }

        [HttpGet("getbyaccount")]
        public async Task<IActionResult> GetByAccount(int id)
        {
            return Ok(await Service.GetByAccount(id));
        }

        [HttpPost("removebyaccount")]
        public async Task<IActionResult> RemoveByAccount(int accountId, int bookId)
        {
            await Service.RemoveByAccount(accountId, bookId);
            return Ok();
        }
    }
}
