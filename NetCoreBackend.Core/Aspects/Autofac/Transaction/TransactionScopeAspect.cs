using Castle.DynamicProxy;
using NetCoreBackend.Core.Utilities.Interceptors;
using System;
using System.Transactions;

namespace NetCoreBackend.Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
