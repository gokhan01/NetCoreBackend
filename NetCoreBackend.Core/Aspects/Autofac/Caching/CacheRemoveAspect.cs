using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using NetCoreBackend.Core.CrossCuttingConcerns.Caching;
using NetCoreBackend.Core.Utilities.Interceptors;
using NetCoreBackend.Core.Utilities.IoC;

namespace NetCoreBackend.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;
        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
