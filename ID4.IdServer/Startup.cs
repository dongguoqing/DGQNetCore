using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Configuration;
using Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ID4.IdServer
{
    public class Startup
    {

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
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
            var idResources = new List<IdentityResource>
            {
                new IdentityResources.OpenId(), //必须要添加，否则报无效的scope错误
		        new IdentityResources.Profile()
            };
            services.AddIdentityServer().AddDeveloperSigningCredential().AddInMemoryIdentityResources(idResources).AddInMemoryApiResources(Config.GetApiResources()).AddInMemoryClients(Config.GetClients()).AddResourceOwnerValidator<ResourceOwnerPasswordValidator>().AddProfileService<ProfileService>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //获取配置文件中的连接字符串
            var sqlConnection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApiDBContent>(option => option.UseSqlServer(sqlConnection));

            services.AddScoped<DbContext>(provider => provider.GetService<ApiDBContent>());
            services.AddCors();
            services.AddMvc()
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
        }
    }
}
