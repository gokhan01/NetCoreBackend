using NetCoreBackend.BLL.Abstract;
using NetCoreBackend.BLL.Constants;
using NetCoreBackend.Core.Entities.Concrete;
using NetCoreBackend.Core.Utilities.Results;
using NetCoreBackend.DAL.Abstract;
using System.Collections.Generic;

namespace NetCoreBackend.BLL.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        IResult IUserService.Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        IDataResult<User> IUserService.GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.Email == email));
        }

        IDataResult<List<OperationClaim>> IUserService.GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
    }
}
