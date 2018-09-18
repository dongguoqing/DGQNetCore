using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Model;
using AspectCore.Extensions.DependencyInjection;
using LoginServer.Middleware;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using LoginServer.Exceptions;

namespace LoginServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            //loggerFactory.AddNLog();
            //app.AddNLogWeb();
            //env.ConfigureNLog("nlog.config");
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("autofac.json")
                .AddEnvironmentVariables(); ;
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //获取配置文件中的连接字符串
            var sqlConnection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApiDBContent>(option => option.UseSqlServer(sqlConnection));

            services.AddScoped<DbContext>(provider => provider.GetService<ApiDBContent>());
            services.AddCors();
            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
               .AddJsonOptions(options => options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss")
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddControllersAsServices();

            return RegisterAutofac(services);
        }

        private IServiceProvider RegisterAutofac(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);
            var module = new ConfigurationModule(Configuration);
            builder.RegisterModule(module);
            this.Container = builder.Build();

            return new AutofacServiceProvider(this.Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
            });

            loggerFactory.AddNLog();
            app.AddNLogWeb();
            env.ConfigureNLog("nlog.config");

            app.UseUserAuthentication();//要放在UseMvc前面  
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc();

            appLifetime.ApplicationStopped.Register(() => this.Container.Dispose());
        }
    }
}