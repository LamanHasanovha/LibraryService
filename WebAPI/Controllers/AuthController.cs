using Core.Business.Abstract;
using Core.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IOperationClaimService _operationClaimService;

        public AuthController(IAuthService authService, IUserService userService, IUserOperationClaimService userOperationClaimService,
                                IOperationClaimService operationClaimService)
        {
            _authService = authService;
            _userService = userService;
            _userOperationClaimService = userOperationClaimService;
            _operationClaimService = operationClaimService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginModel userForLoginModel)
        {
            var userToLogin = _authService.Login(userForLoginModel);
            var accessToken = _authService.CreateAccessToken(userToLogin);

            var result = new UserLoginResponseModel(userToLogin, accessToken);
            return Ok(result);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterModel userForRegisterModel)
        {
            var userToRegister = _authService.Register(userForRegisterModel);
            var accessToken = _authService.CreateAccessToken(userToRegister);
            var result = new UserRegisterResponseModel(userToRegister, accessToken);
            return Ok(result);
        }

        [HttpPost("registercheck")]
        public IActionResult RegisterCheck(UserForRegisterCheckRequestModel user)
        {
            return Ok(_authService.RegisterCheck(user));
        }

        [HttpGet("getallroles")]
        public IActionResult GetAllRoles()
        {
            return Ok(_operationClaimService.GetAll());
        }

        private TTarget Map<TCurrent, TTarget>(TCurrent source)
        {
            var data = Activator.CreateInstance<TTarget>();

            var targetProperties = source.GetType().GetProperties();
            var destinationProperties = data.GetType().GetProperties();

            foreach (var dp in destinationProperties)
            {
                var val = targetProperties.FirstOrDefault(p => p.Name == dp.Name)?.GetValue(source);
                dp.SetValue(data, val);
            }

            return data;
        }
    }
}