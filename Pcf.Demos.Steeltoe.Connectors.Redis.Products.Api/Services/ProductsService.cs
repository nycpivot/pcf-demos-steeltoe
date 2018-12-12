using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Pcf.Demos.Steeltoe.Domain.Products;
using Steeltoe.Common.Discovery;

namespace Pcf.Demos.Steeltoe.Connectors.Redis.Products.Api.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IDistributedCache cache;

        public ProductsService(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public static void Load(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var cache = serviceScope.ServiceProvider.GetService<IDistributedCache>();

                if (cache != null)
                {
                    var bytes = cache.Get("Products");
                    if (bytes == null || bytes.Length == 0)
                    {
                        var discoveryClient = serviceProvider.GetService<IDiscoveryClient>();
                        var handler = new DiscoveryHttpClientHandler(discoveryClient);
                        var http = new HttpClient(handler, false);

                        var productsUri = "http://pcf-demos-steeltoe-connectors-sqlserver-products-api/api/products/";
                        var response = http.GetAsync(productsUri).Result;
                        var json = response.Content.ReadAsStringAsync().Result;

                        cache.SetString("Products", json);
                    }
                }
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            var json = cache.GetString("Products");

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

            return products;
        }
    }
}