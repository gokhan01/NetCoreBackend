using System;
using System.Linq;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using NetCoreBackend.BLL.Abstract;
using NetCoreBackend.BLL.Concrete;
using NetCoreBackend.Core.Utilities.Interceptors;
using NetCoreBackend.Core.Utilities.Security.Jwt;
using NetCoreBackend.DAL.Abstract;
using NetCoreBackend.DAL.Concrete.EntityFramework;

namespace NetCoreBackend.BLL.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<ProductManager>().As<IProductService>();
            //builder.RegisterType<EfProductDal>().As<IProductDal>();

            //builder.RegisterType<CategoryManager>().As<ICategoryService>();
            //builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            //builder.RegisterType<UserManager>().As<IUserService>();
            //builder.RegisterType<EfUserDal>().As<IUserDal>();

            //builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .Where(type => type.Namespace.Contains("Concrete"))
                .As(type => type.GetInterfaces().FirstOrDefault(i => i.Name.Equals($"I{type.Name}")))
                /*.InterceptedBy(typeof(AspectInterceptorSelector))*/;

            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load("NetCoreBackend.DAL"))
                .Where(type => type.Namespace.Contains("Concrete"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
