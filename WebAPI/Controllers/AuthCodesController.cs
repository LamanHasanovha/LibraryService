using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthCodesController : BaseController<IAuthCodeService, AuthCode, AuthCodeAddRequestModel, AuthCodeUpdateRequestModel, AuthCodeDeleteRequestModel>
    {
        public AuthCodesController(IAuthCodeService service) : base(service)
        {
        }

        [HttpPost("sendauthcode")]
        public async Task<IActionResult> SendAuthCode(int accountId, string email)
        {
            await Service.SendAuthCode(accountId, email);
            return Ok();
        }

        [HttpPost("checkauthcode")]
        public async Task<IActionResult> CheckAuthCode(int accountId, string code)
        {
            return Ok(await Service.CheckAuthCode(accountId, code));
        }
    }
}
