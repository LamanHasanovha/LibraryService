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
    public class CartsController : BaseController<ICartService, Cart, ChartAddRequestModel, ChartUpdateRequestModel, ChartDeleteRequestModel>
    {
        public CartsController(ICartService service) : base(service)
        {
        }

        [HttpGet("check")]
        public async Task<IActionResult> Check(int accountId, int recordId, int type)
        {
            return Ok(await Service.Check(accountId, recordId, (ProductTypes)type));
        }

        [HttpPost("removebyaccount")]
        public async Task<IActionResult> RemoveByAccount(int accountId, int recordId, int type)
        {
            await Service.RemoveByAccount(accountId, recordId, (ProductTypes)type);
            return Ok();
        }

        [HttpGet("getbyaccount")]
        public async Task<IActionResult> GetByAccount(int id)
        {
            return Ok(await Service.GetByAccount(id));
        }
    }
}
