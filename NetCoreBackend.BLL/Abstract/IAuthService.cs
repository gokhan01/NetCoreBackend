using NetCoreBackend.Core.Entities.Concrete;
using NetCoreBackend.Core.Utilities.Results;
using NetCoreBackend.Core.Utilities.Security.Jwt;
using NetCoreBackend.Entities.Dtos;

namespace NetCoreBackend.BLL.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
