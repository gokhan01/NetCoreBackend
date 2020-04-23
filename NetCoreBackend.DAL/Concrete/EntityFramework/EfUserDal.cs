using NetCoreBackend.Core.DAL.EntityFramework;
using NetCoreBackend.Core.Entities.Concrete;
using NetCoreBackend.DAL.Abstract;
using NetCoreBackend.DAL.Concrete.EntityFramework.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreBackend.DAL.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();
            }
        }
    }
}
