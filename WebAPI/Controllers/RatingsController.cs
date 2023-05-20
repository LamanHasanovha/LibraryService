using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Constants;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : BaseController<IRatingService, Rating, RatingAddRequestModel, RatingUpdateRequestModel, RatingDeleteRequestModel>
    {
        public RatingsController(IRatingService service) : base(service)
        {
        }

        [HttpGet("getbyrecord")]
        public async Task<IActionResult> GetByRecord(int recordId, int type)
        {
            return Ok(await Service.GetByRecord(recordId, (RatingTypes)type));
        }

        [HttpPost("saverating")]
        public async Task<IActionResult> SaveRating(Rating rating)
        {
            await Service.SaveRating(rating);
            return Ok();
        }
    }
}
