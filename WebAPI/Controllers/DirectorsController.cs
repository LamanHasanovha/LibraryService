using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : BaseController<IDirectorService, Director, DirectorAddRequestModel, DirectorUpdateRequestModel, DirectorDeleteRequestModel>
    {
        public DirectorsController(IDirectorService service) : base(service)
        {
        }
    }
}
