using System.Diagnostics;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using WarrantyTracking.Core.Utilities.Interceptors;
using WarrantyTracking.Core.Utilities.IoC;

namespace WarrantyTracking.Core.Aspects.Autofac.Performans
{
    public class PerformansAspect : MethodInterception
    {
        private int _inverval;
        private Stopwatch _stopwatch;

        public PerformansAspect(int inverval)
        {
            _inverval = inverval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _inverval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name} --> {_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}