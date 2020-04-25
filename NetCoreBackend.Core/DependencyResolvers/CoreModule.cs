using Microsoft.Extensions.DependencyInjection;
using NetCoreBackend.Core.Utilities.IoC;

namespace NetCoreBackend.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
        }
    }
}
