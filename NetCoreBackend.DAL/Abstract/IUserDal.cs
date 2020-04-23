using NetCoreBackend.Core.DAL;
using NetCoreBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBackend.DAL.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
