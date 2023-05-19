using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : BaseController<IActorService, Actor, ActorAddRequestModel, ActorUpdateRequestModel, ActorDeleteRequestModel>
    {
        public ActorsController(IActorService service) : base(service)
        {
        }
    }
}
