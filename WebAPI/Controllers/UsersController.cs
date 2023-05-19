using Core.Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Models;
using Core.WebAPI;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<IUserService, User, UserAddRequestModel, UserUpdateRequestModel, UserDeleteRequestModel>
    {
        public UsersController(IUserService service) : base(service)
        {
        }
    }
}
