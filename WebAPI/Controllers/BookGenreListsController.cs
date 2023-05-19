using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookGenreListsController : BaseController<IBookGenreListService, BookGenreList, BookGenreListAddRequestModel, BookGenreListUpdateRequestModel, BookGenreListDeleteRequestModel>
    {
        public BookGenreListsController(IBookGenreListService service) : base(service)
        {
        }

        [HttpPost("deletebybook")]
        public async Task<IActionResult> DeleteByBook(int id)
        {
            return Ok(await Service.DeleteByBook(id));
        }

        [HttpPost("updatebybook")]
        public async Task<IActionResult> UpdateByBook(List<BookGenreList> list)
        {
            return Ok(await Service.UpdateByBook(list));
        }

        [HttpGet("getbybook")]
        public async Task<IActionResult> GetByBook(int id)
        {
            return Ok(await Service.GetByBook(id));
        }
    }
}
