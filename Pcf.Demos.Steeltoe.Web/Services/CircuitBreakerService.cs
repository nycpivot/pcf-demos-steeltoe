using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pcf.Demos.Steeltoe.Web.Models;
using Steeltoe.Common.Discovery;

namespace Pcf.Demos.Steeltoe.Web.Services
{
    public class CircuitBreakerService : ICircuitBreakerService
    {
        private readonly HttpClient http;

        public CircuitBreakerService(IDiscoveryClient client)
        {
            var handler = new DiscoveryHttpClientHandler(client);

            this.http = new HttpClient(handler, false)
            {
                BaseAddress = new Uri("http://pcf-demos-steeltoe-api/api/circuit-breaker/")
            };
        }

        public async Task<IEnumerable<ProductViewModel>> GetCustomerWishlist()
        {
            var response = http.GetAsync(String.Empty).Result;
            var json = await response.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<IEnumerable<ProductViewModel>>(json);

            return products;
        }
    }
}