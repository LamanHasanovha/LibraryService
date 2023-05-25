using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : BaseController<IActivityService, Activity, ActivityAddRequestModel, ActivityUpdateRequestModel, ActivityDeleteRequestModel>
    {
        public ActivitiesController(IActivityService service) : base(service)
        {
        }
    }
}
