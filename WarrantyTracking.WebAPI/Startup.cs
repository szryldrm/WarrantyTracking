using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using WarrantyTracking.Business.Abstract;
using WarrantyTracking.Business.Concrete;
using WarrantyTracking.Core.CrossCuttingConcerns.Caching;
using WarrantyTracking.Core.CrossCuttingConcerns.Caching.Redis;
using WarrantyTracking.Core.DependencyResolvers;
using WarrantyTracking.Core.Extensions;
using WarrantyTracking.Core.Settings;
using WarrantyTracking.Core.Settings.MSSQLDbSettings;
using WarrantyTracking.Core.Utilities.IoC;
using WarrantyTracking.DataAccess.Abstract;
using WarrantyTracking.DataAccess.Concrete;
using WarrantyTracking.DataAccess.Concrete.EntityFramework.Contexts;

namespace WarrantyTracking.WebAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<WarrantyTrackingSqlContext>(
            //    options => options.UseSqlServer(Configuration.GetSection("MSSQLDbSettings").GetSection("ConnectionString").Value));
            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));
            services.Configure<RedisSettings>(Configuration.GetSection("RedisSettings"));
            //services.Configure<MSSQLDbSettings>(Configuration.GetSection("MSSQLDbSettings"));

            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            services.AddSingleton<IRedisSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<RedisSettings>>().Value);
            //services.AddSingleton<IMSSQLDbSettings>(serviceProvider =>
                //serviceProvider.GetRequiredService<IOptions<MSSQLDbSettings>>().Value);

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetSection("RedisSettings").GetSection("RedisHostIP").Value 
                + ":" + Configuration.GetSection("RedisSettings").GetSection("RedisPort").Value;
            });

            services.AddControllers();

            services.AddScoped<IWarrantyService, WarrantyManager>();
            services.AddScoped<IWarrantyDal, EfWarrantyDal>();

            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule(Configuration),
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.ConfigureCustomExceptionMiddleware();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}