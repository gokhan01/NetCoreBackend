using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;

namespace NetCoreBackend.Core.Utilities.Interceptors
{
    //Autofac
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();

            var methodAtributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);

            classAttributes.AddRange(methodAtributes);

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
