using Core.Business.Abstract;
using Core.Business.Validation;
using Core.CCC.Exception;
using Core.Constants;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Core.Entities.Models;
using Core.Features.Security.Hashing;
using Core.Features.Security.Jwt;

namespace Core.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public User Register(UserForRegisterModel userForRegister)
        {
            HashingHelper.CreatePasswordHash(userForRegister.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Email = userForRegister.Email,
                FirstName = userForRegister.FirstName,
                LastName = userForRegister.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return user;
        }

        public User Login(UserForLoginModel userForLogin)
        {
            var userToCheck = _userService.GetByMail(userForLogin.Email);
            if (userToCheck == null)
            {
                throw new BusinessException(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLogin.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                throw new BusinessException(Messages.PasswordError);
            }

            return userToCheck;
        }

        public void UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                throw new BusinessException(Messages.UserAlreadyExists);
            }
        }

        public AccessToken CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return accessToken;
        }

        public bool RegisterCheck(UserForRegisterCheckRequestModel userForRegister)
        {
            var result = true;

            try
            {
                UserExists(userForRegister.Email);
                HashingHelper.CreatePasswordHash(userForRegister.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var user = new User
                {
                    Email = userForRegister.Email,
                    FirstName = userForRegister.FirstName,
                    LastName = userForRegister.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };
                ValidationTool.Validate(new UserValidator(), user);

            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}
