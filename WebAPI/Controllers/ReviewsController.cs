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
    public class ReviewsController : BaseController<IReviewService, Review, ReviewAddRequestModel, ReviewUpdateRequestModel, ReviewDeleteRequestModel>
    {
        public ReviewsController(IReviewService service) : base(service)
        {
        }

        [HttpGet("getbytype")]
        public async Task<IActionResult> GetByType(int recordId,  int type)
        {
            return Ok(await Service.GetByType(recordId, (RatingTypes)type));
        }

        [HttpGet("getbyaccount")]
        public async Task<IActionResult> GetByAccount(int id, int recordId, int type)
        {
            return Ok(await Service.GetByAccount(id, recordId, (RatingTypes)type));
        }
    }
}
