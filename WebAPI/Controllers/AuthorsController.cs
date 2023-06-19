using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : BaseController<IAuthorService, Author, AuthorAddRequestModel, AuthorUpdateRequestModel, AuthorDeleteRequestModel>
    {
        public AuthorsController(IAuthorService service) : base(service)
        {
        }

        [HttpGet("getrandomauthor")]
        public async Task<IActionResult> GetRandomAuthor()
        {
            return Ok(await Service.GetRandomAuthor());
        }
    }
}
