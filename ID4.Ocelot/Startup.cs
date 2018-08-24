using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using IdentityServer4.AccessTokenValidation;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ID4.Ocelot
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Action<IdentityServerAuthenticationOptions> isaOptMsg = o =>
            {
                o.ApiName = "MsgAPI";
                o.ApiSecret = "123321";
                o.Authority = "http://192.168.1.47:9500";
                o.RequireHttpsMetadata = false;
                o.SupportedTokens = SupportedTokens.Both;
            };
            Action<IdentityServerAuthenticationOptions> isaOptProduct = o =>
            {
                o.ApiName = "ProductAPI";
                o.ApiSecret = "123321";
                o.Authority = "http://192.168.1.47:9500";
                o.RequireHttpsMetadata = false;
                o.SupportedTokens = SupportedTokens.Both;
            };
            //对配置文件中使用了ChatKey配置了AuthenticationProviderKey = MsgKey的路由规则使用如下
            services.AddAuthentication().AddIdentityServerAuthentication("MsgKey",isaOptMsg).AddIdentityServerAuthentication("ProductKey",isaOptMsg);
            services.AddOcelot();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOcelot().Wait();
        }
    }
}
