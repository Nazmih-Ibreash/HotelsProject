using Hotels.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            if (args.Length > 0 && args[0] == "/seed")
            {
                RunSeeding(host);
                return;
            }
            else
            {
                host.Run();
            }
            
        }

        private static void RunSeeding(IHost host)
        {
           var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
           using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<HotelSeeder>();
                seeder.seed();
            }
           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(AddConfiguration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void AddConfiguration(HostBuilderContext cntx, IConfigurationBuilder bldr)
        {
            bldr.Sources.Clear();

            bldr.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", false, true)
                .AddEnvironmentVariables();
        }
    }
}
