using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using NetCoreBackend.Core.CrossCuttingConcerns.Logging;
using NetCoreBackend.Core.CrossCuttingConcerns.Logging.Log4Net;
using NetCoreBackend.Core.CrossCuttingConcerns.Logging.SeriLog;
using NetCoreBackend.Core.Utilities.Interceptors;
using NetCoreBackend.Core.Utilities.Messages;

namespace NetCoreBackend.Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private SerilogServiceBase _loggerServiceBase;

        public LogAspect(Type loggerService)
        {
            if (!typeof(SerilogServiceBase).IsAssignableFrom(loggerService))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }

            _loggerServiceBase = (SerilogServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase.Info(GetLogDetail(invocation));
        }

        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetail;
        }
    }
}
