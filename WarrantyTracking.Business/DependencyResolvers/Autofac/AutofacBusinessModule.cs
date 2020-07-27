using Autofac;
using WarrantyTracking.Business.Abstract;
using WarrantyTracking.Business.Concrete;
using WarrantyTracking.Core.CrossCuttingConcerns.Caching;
using WarrantyTracking.Core.CrossCuttingConcerns.Caching.Redis;
using WarrantyTracking.DataAccess.Abstract;
using WarrantyTracking.DataAccess.Concrete;

namespace WarrantyTracking.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WarrantyManager>().As<IWarrantyService>();
            builder.RegisterType<EfWarrantyDal>().As<IWarrantyDal>();
        }
    }
}