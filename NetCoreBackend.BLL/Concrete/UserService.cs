using NetCoreBackend.BLL.Abstract;
using NetCoreBackend.Core.Entities.Concrete;
using NetCoreBackend.DAL.Abstract;
using System.Collections.Generic;

namespace NetCoreBackend.BLL.Concrete
{
    public class UserService : IUserService
    {
        IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
