using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pcf.Demos.Steeltoe.Web.Models;
using Steeltoe.Common.Discovery;

namespace Pcf.Demos.Steeltoe.Web.Services
{
    public class CircuitBreakerService : ICircuitBreakerProductService
    {
        private readonly HttpClient http;

        public CircuitBreakerService(IDiscoveryClient client)
        {
            var handler = new DiscoveryHttpClientHandler(client);

            this.http = new HttpClient(handler, false);
        }

        public async Task<ServiceDetailsModel> GetServiceDetails()
        {
            var url = "http://pcf-demos-steeltoe-api/api/circuit-breaker";

            var response = http.GetAsync(url).Result;
            var json = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<ServiceDetailsModel>(json);

            return model;
        }

        public async Task<ServiceDetailsModel> GetServiceDetailsFallback()
        {
            var url = "http://pcf-demos-steeltoe-fallback-api/api/circuit-breaker-fallback";

            var response = http.GetAsync(url).Result;
            var json = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<ServiceDetailsModel>(json);

            return model;
        }

        Task<IEnumerable<ProductViewModel>> ICircuitBreakerProductService.GetServiceDetails()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ProductViewModel>> ICircuitBreakerProductService.GetServiceDetailsFallback()
        {
            throw new NotImplementedException();
        }
    }
}