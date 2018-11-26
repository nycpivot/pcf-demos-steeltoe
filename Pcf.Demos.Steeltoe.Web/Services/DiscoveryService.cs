using Newtonsoft.Json;
using Steeltoe.Common.Discovery;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pcf.Demos.Steeltoe.Web.Services
{
    public class DiscoveryService : IDiscoveryService
    {
        private readonly HttpClient http;

        public DiscoveryService(IDiscoveryClient client)
        {
            var handler = new DiscoveryHttpClientHandler(client);

            this.http = new HttpClient(handler, false)
            {
                BaseAddress = new Uri("http://pcf-demos-steeltoe-service-discovery-api/api/discovery/")
            };
        }

        public async Task<CloudFoundryApplicationOptions> GetServiceDetails()
        {
            var response = http.GetAsync(String.Empty).Result;
            var json = await response.Content.ReadAsStringAsync();

            var appOptions = JsonConvert.DeserializeObject<CloudFoundryApplicationOptions>(json);

            return appOptions;
        }
    }
}