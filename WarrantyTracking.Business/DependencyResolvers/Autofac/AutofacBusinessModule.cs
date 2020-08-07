using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using WarrantyTracking.Business.Abstract;
using WarrantyTracking.Business.Concrete;
using WarrantyTracking.Core.Utilities.Interceptors;
using WarrantyTracking.DataAccess.Abstract;
using WarrantyTracking.DataAccess.Concrete;

namespace WarrantyTracking.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WarrantyManager>().As<IWarrantyService>();
            builder.RegisterType<EfWarrantyDal>().As<IWarrantyDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(
                    new ProxyGenerationOptions()
                    {
                        Selector = new AspectInterceptorSelector()
                    }).SingleInstance();
        }
    }
}