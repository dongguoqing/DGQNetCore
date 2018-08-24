using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Consul;

namespace MyWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().UseUrls("http://192.168.1.47:8885").ConfigureAppConfiguration((hostingContext, builder) =>
                {
                    //加载Configuration.json  为了确保能找到这个文件 得把这个文件拷到bin目录去
                    builder.AddJsonFile("Configuration.json", false, true);
                });
    }
}
