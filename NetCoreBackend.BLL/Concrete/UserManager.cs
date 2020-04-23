using NetCoreBackend.BLL.Abstract;
using NetCoreBackend.Core.Utilities.Results;
using NetCoreBackend.DAL.Abstract;
using NetCoreBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBackend.BLL.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        IDataResult<User> IUserService.Add(User user)
        {
            return new SuccessDataResult<User>(_userDal.Add(user));
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
