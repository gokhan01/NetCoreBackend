using NetCoreBackend.Core.Entities.Concrete;
using System.Collections.Generic;

namespace NetCoreBackend.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
