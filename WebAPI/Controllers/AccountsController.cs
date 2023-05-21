using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<IAccountService, Account, AccountAddRequestModel, AccountUpdateRequestModel, AccountDeleteRequestModel>
    {
        public AccountsController(IAccountService service) : base(service)
        {
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountRegisterModel model)
        {
            return Ok(await Service.Register(model));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AccountLoginModel model)
        {
            return Ok(await Service.Login(model));
        }

        [HttpPost("updatewithpass")]
        public async Task<IActionResult> UpdateWithPassword(AccountUpdateModel model)
        {
            return Ok(await Service.UpdateWithPassword(model));
        }

        [HttpPost("updateinfo")]
        public async Task<IActionResult> UpdateInfo(AccountUpdateInfoRequestModel model)
        {
            return Ok(await Service.UpdateInfo(model));
        }

        [HttpGet("checkpass")]
        public async Task<IActionResult> CheckPass(string username, string password)
        {
            return Ok(await Service.CheckPass(username, password));
        }
    }
}
