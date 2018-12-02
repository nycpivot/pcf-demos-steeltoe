using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Pivotal.Extensions.Configuration.ConfigServer;

namespace Pcf.Demos.Steeltoe.Web
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
                    var env = context.HostingEnvironment;

                    config.AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                        .AddEnvironmentVariables()
                        .AddConfigServer(env);
                })
                //.AddCloudFoundry() //VCAP_APPLICATION & VCAP_SERVICES, but seems to work without adding it
                //.AddConfigServer() //moved this line to the above block
                .UseStartup<Startup>()
                .Build();
    }
}