using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Steeltoe.Common.Discovery;

namespace Pcf.Demos.Steeltoe.Api.Services
{
    public class CircuitBreakerCustomerWishlistService : ICircuitBreakerCustomerWishlistService
    {
        private readonly HttpClient http;

        public CircuitBreakerCustomerWishlistService(IDiscoveryClient discoveryClient)
        {
            var handler = new DiscoveryHttpClientHandler(discoveryClient);

            this.http = new HttpClient(handler, false);
        }

        public async Task<IEnumerable<Domain.Customers.Product>> GetWishlist()
        {
            var url = "http://pcf-demos-steeltoe-connectors-sqlserver-customers-api/api/wishlist";

            var response = http.GetAsync(url).Result;
            var json = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<IEnumerable<Domain.Customers.Product>>(json);

            return model;
        }

        public async Task<IEnumerable<Domain.Products.Product>> GetProducts()
        {
            var url = "http://pcf-demos-steeltoe-connectors-redis-products-api/api/products";

            var response = http.GetAsync(url).Result;
            var json = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<IEnumerable<Domain.Products.Product>>(json);

            return model;
        }
    }
}