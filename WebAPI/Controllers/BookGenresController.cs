using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookGenresController : BaseController<IBookGenreService, BookGenre, BookGenreAddRequestModel, BookGenreUpdateRequestModel, BookGenreDeleteRequestModel>
    {
        public BookGenresController(IBookGenreService service) : base(service)
        {
        }
    }
}
