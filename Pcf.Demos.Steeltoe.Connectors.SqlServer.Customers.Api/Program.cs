using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace Pcf.Demos.Steeltoe.Connectors.SqlServer.Customers.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseCloudFoundryHosting()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json")
                        .AddCloudFoundry();
                })
                //.AddCloudFoundry()
                .UseStartup<Startup>()
                .Build();
    }
}