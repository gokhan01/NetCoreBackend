using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using NetCoreBackend.Core.CrossCuttingConcerns.Caching;
using NetCoreBackend.Core.Utilities.Interceptors;
using NetCoreBackend.Core.Utilities.IoC;
using System.Linq;

namespace NetCoreBackend.Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;
        public CacheAspect(int duration = 60)//60 dakika default
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();

            //NetCoreBackend.BLL.Abstract.IProductService.GetListByCategory(1)
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdded(key))//key değeri karşılığı cache de varmı kontrol edilir
            {
                invocation.ReturnValue = _cacheManager.Get(key);//key değeri varsa metod dönüş değeri cache den getirilir
                return;
            }
            invocation.Proceed();//key değeri karşılığı cache de yoksa metod çalıştırılır
            _cacheManager.Add(key, invocation.ReturnValue, _duration);//key değerine göre cache doldurulur
        }
    }
}
