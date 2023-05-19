using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController<IBookService, Book, BookAddRequestModel, BookUpdateRequestModel, BookDeleteRequestModel>
    {
        public BooksController(IBookService service) : base(service)
        {

        }

        [HttpGet("getbooks")]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await Service.GetBooks());
        }

        [HttpGet("getrandombook")]
        public async Task<IActionResult> GetRandomBook()
        {
            return Ok(await Service.GetRandomBook());
        }

        [HttpGet("getbyauthor")]
        public async Task<IActionResult> GetByAuthor(int id)
        {
            return Ok(await Service.GetByAuthor(id));
        }

        [HttpGet("getbookbyid")]
        public async Task<IActionResult> GetBookById(int id)
        {
            return Ok(await Service.GetBookById(id));
        }
    }
}
