using NetCoreBackend.BLL.Abstract;
using NetCoreBackend.BLL.Constants;
using NetCoreBackend.Core.Entities.Concrete;
using NetCoreBackend.Core.Utilities.Results;
using NetCoreBackend.Core.Utilities.Security.Jwt;
using NetCoreBackend.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBackend.BLL.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            throw new NotImplementedException();
        }

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
