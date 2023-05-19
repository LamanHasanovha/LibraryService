using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookWishListsController : BaseController<IBookWishListService, BookWishList, BookWishListAddRequestModel, BookWishListUpdateRequestModel, BookWishListDeleteRequestModel>
    {
        public BookWishListsController(IBookWishListService service) : base(service)
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
