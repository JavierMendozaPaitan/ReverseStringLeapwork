using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReverseStringLeapwork.Abstractions;
using ReverseStringLeapwork.Engines;
using ReverseStringLeapwork.Services;
using System;

namespace ReverseStringApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            ReverseAndPrintString(host.Services);

            //ReverseAndPrintText(host.Services);
        }

        static void ReverseAndPrintString(IServiceProvider services)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            ReverseStringAppService service = provider.GetRequiredService<ReverseStringAppService>();
            service.ReverseAndPrintString();
        }

        static void ReverseAndPrintText(IServiceProvider services)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            ReverseStringAppService service = provider.GetRequiredService<ReverseStringAppService>();
            service.ReverseAndPrintText();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IPrintStringEngine, PrintStringEngine>()
                    .AddSingleton<IReverseStringEngine, ReverseStringEngine>()
                    .AddSingleton<IReverseAndPrintStringService, ReverseAndPrintStringService>()
                    .AddTransient<ReverseStringAppService>();
            });
    }
}
