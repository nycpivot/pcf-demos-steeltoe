using Microsoft.AspNetCore.Mvc;
using Pcf.Demos.Steeltoe.Api.Commands;

namespace Pcf.Demos.Steeltoe.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/circuit-breaker")]
    public class CircuitBreakerController : Controller
    {
        private readonly CircuitBreakerCustomerWishlistCommand circuitBreakerCustomerWishlistCommand;

        public CircuitBreakerController(
            CircuitBreakerCustomerWishlistCommand circuitBreakerCustomerWishlistCommand)
        {
            this.circuitBreakerCustomerWishlistCommand = circuitBreakerCustomerWishlistCommand;
        }

        public IActionResult Get()
        {
            var products = circuitBreakerCustomerWishlistCommand
                .GetCustomerWishlist().Result;

            return Ok(products);
        }
    }
}