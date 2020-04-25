using Castle.DynamicProxy;
using System;

namespace NetCoreBackend.Core.Utilities.Interceptors
{
    //Attribute için kullanılabilecek alanlar ve nasıl kullanılabilecekleri set edilebilir
    //Class seviyesinde
    //Metodlarda,
    //Birden fazla
    //Sub class'larda kullanılabilir
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        //Görev sırası bu özellik ile yönetilecek
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {
        }
    }
}
