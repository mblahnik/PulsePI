using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Autofac;
using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.DataAccess;
using PulsePI.Service.ServiceInterfaces;
using PulsePI.Service;
using System.IO;
using PulsePI.Models;
using Microsoft.EntityFrameworkCore;

namespace PulsePI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PulsePiDBContext>(
                options => options.UseSqlServer(Configuration["ConnectionStrings:MyDbConnection"]));
            services.AddDbContext<PulsePiDBContext>();
            services.AddControllers();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAccountDao,AccountDao>();
            services.AddTransient<IHeartRateRecordService, HeartRateRecordService>();
            services.AddTransient<IBiometricService, BiometricService>();
            services.AddTransient<IHeartRateRecordDao, HeartRateRecordDao>();
            services.AddTransient<IHeartRateRecordDao, HeartRateRecordDao>();
            services.AddTransient<IBiometricDataDao, BiometricDataDao>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) => {
                await next();
                if(context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }

            });
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
