using NetCoreBackend.Core.Entities.Concrete;
using NetCoreBackend.Core.Utilities.Results;
using System.Collections.Generic;

namespace NetCoreBackend.BLL.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> Add(User user);
        IDataResult<User> GetByMail(string email);
    }
}
