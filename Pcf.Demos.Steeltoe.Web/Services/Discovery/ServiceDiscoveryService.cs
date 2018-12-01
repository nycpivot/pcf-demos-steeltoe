using Newtonsoft.Json;
using Steeltoe.Common.Discovery;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pcf.Demos.Steeltoe.Web.Services.Discovery
{
    public class ServiceDiscoveryService : IServiceDiscoveryService
    {
        private readonly HttpClient http;

        public ServiceDiscoveryService(IDiscoveryClient client)
        {
            var handler = new DiscoveryHttpClientHandler(client);

            this.http = new HttpClient(handler, false)
            {
                BaseAddress = new Uri("http://pcf-demos-steeltoe-api/api/service-discovery/")
            };
        }

        public async Task<CloudFoundryApplicationOptions> GetServiceDetails()
        {
            var response = http.GetAsync(String.Empty).Result;
            var json = await response.Content.ReadAsStringAsync();

            var appOptions = JsonConvert.DeserializeObject<CloudFoundryApplicationOptions>(json);

            //var ip = IPAddress.Parse(appOptions.InstanceIP);
            //var host = Dns.GetHostEntry(ip);

            //appOptions.ServerName = host.HostName;

            return appOptions;
        }
    }
}