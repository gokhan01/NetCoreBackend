using Castle.DynamicProxy;
using NetCoreBackend.Core.Aspects.Autofac.Exception;
using NetCoreBackend.Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;
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
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new ExceptionLogAspect(typeof(GrayLogLogger)));
            classAttributes.Add(new ExceptionLogAspect(typeof(SerilogFileLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
