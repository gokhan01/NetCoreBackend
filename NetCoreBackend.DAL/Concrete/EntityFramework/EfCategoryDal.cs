using NetCoreBackend.Core.DAL.EntityFramework;
using NetCoreBackend.DAL.Abstract;
using NetCoreBackend.DAL.Concrete.EntityFramework.Contexts;
using NetCoreBackend.Entities.Concrete;

namespace NetCoreBackend.DAL.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
    }
}
