using LittleDelights.Data.Repositories;
using LittleDelights.Model.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittleDelights.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            RunSeeding(host);

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void RunSeeding(IHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var itemRepository = scope.ServiceProvider.GetService<ItemRepository>();

                itemRepository.AddItem(new Milk(DateTime.Now));
                itemRepository.AddItem(new Fish(DateTime.Now));
                itemRepository.AddItem(new Wine(new DateTime(2022, 3, 1), Model.Enums.WineType.Red));
                itemRepository.AddItem(new Wine(new DateTime(2022, 5, 1), Model.Enums.WineType.Sparkling));
            }
        }
    }
}
