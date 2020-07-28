using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using WarrantyTracking.Core.CrossCuttingConcerns.Caching;
using WarrantyTracking.Core.CrossCuttingConcerns.Caching.Redis;
using WarrantyTracking.Core.Utilities.IoC;

namespace WarrantyTracking.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<ICacheManager, RedisCacheManager>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
