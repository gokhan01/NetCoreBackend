using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NetCoreBackend.Core.CrossCuttingConcerns.Caching;
using NetCoreBackend.Core.CrossCuttingConcerns.Caching.Microsoft;
using NetCoreBackend.Core.Utilities.IoC;
using System.Diagnostics;
using NetCoreBackend.Core.HttpContextAccessors;

namespace NetCoreBackend.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddHttpContextAccessor();//msdn
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<Stopwatch>();
            services.AddTransient<IClaimAccessor, ClaimAccessor>();
        }
    }
}
