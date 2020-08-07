using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using WarrantyTracking.Core.CrossCuttingConcerns.Logging;
using WarrantyTracking.Core.CrossCuttingConcerns.Logging.Log4Net;
using WarrantyTracking.Core.Utilities.Interceptors;
using WarrantyTracking.Core.Utilities.Messages;

namespace WarrantyTracking.Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public LogAspect(Type LoggerService)
        {
            if (LoggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(LoggerService);
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
                MethodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}"),
                LogParameters = logParameters,
                DateTime = DateTime.Now
            };

            return logDetail;
        }
    }
}