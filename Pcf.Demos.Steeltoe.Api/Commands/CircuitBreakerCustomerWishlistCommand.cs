using Pcf.Demos.Steeltoe.Api.Services;
using Steeltoe.CircuitBreaker.Hystrix;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pcf.Demos.Steeltoe.Api.Commands
{
    public class CircuitBreakerCustomerWishlistCommand : HystrixCommand<IEnumerable<Domain.Customers.Product>>
    {
        private readonly ICircuitBreakerCustomerWishlistService circuitBreakerCustomerWishlistService;

        public CircuitBreakerCustomerWishlistCommand(
            IHystrixCommandOptions hystrixCommandOptions,
            ICircuitBreakerCustomerWishlistService circuitBreakerCustomerWishlistService) : base(hystrixCommandOptions)
        {
            this.circuitBreakerCustomerWishlistService = circuitBreakerCustomerWishlistService;
        }

        public async Task<IEnumerable<Domain.Customers.Product>> GetCustomerWishlist()
        {
            return await ExecuteAsync();
        }

        protected override async Task<IEnumerable<Domain.Customers.Product>> RunAsync()
        {
            var result = await circuitBreakerCustomerWishlistService.GetWishlist();

            return result;
        }

        protected override async Task<IEnumerable<Domain.Customers.Product>> RunFallbackAsync()
        {
            var products = await circuitBreakerCustomerWishlistService.GetProducts();

            var wishlist = products.Select(p => new Domain.Customers.Product()
            {
                Id = -1,
                ProductId = p.Id,
                ProductName = p.Name,
                Price = p.Price,
                Image = p.Image
            }).ToList();

            return wishlist;
        }

        public void Crash()
        {
            circuitBreakerCustomerWishlistService.Crash();
        }
    }
}