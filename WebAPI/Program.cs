using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependenciesResolves.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               //IoC i�in Business katman�ndaki autofac'i kullanacak
               //Bir kere yap�l�r.
               .UseServiceProviderFactory(new AutofacServiceProviderFactory())
               //IoC i�in Business katman�ndaki autofac'i g�sterecek
               .ConfigureContainer<ContainerBuilder>(builder=> 
               {
                   builder.RegisterModule(new AutofacBusinessModule());
               })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
