using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGenresController : BaseController<IMovieGenreService, MovieGenre, MovieGenreAddRequestModel, MovieGenreUpdateRequestModel, MovieGenreDeleteRequestModel>
    {
        public MovieGenresController(IMovieGenreService service) : base(service)
        {
        }
    }
}
