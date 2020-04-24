using Autofac;
using NetCoreBackend.BLL.Abstract;
using NetCoreBackend.BLL.Concrete;
using NetCoreBackend.Core.Utilities.Security.Jwt;
using NetCoreBackend.DAL.Abstract;
using NetCoreBackend.DAL.Concrete.EntityFramework;

namespace NetCoreBackend.BLL.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
