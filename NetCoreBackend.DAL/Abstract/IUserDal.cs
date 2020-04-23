using NetCoreBackend.Core.DAL;
using NetCoreBackend.Core.Entities.Concrete;
using System.Collections.Generic;

namespace NetCoreBackend.DAL.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
