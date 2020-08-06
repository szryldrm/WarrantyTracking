using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using WarrantyTracking.Core.CrossCuttingConcerns.Caching;
using WarrantyTracking.Core.Utilities.Interceptors;
using WarrantyTracking.Core.Utilities.IoC;

namespace WarrantyTracking.Core.Aspects.Autofac.Caching
{
    public class CacheFlushAspect : MethodInterception
    {
        private ICacheManager _cacheManager;

        public CacheFlushAspect() => _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.Clear();
        }
    }
}
