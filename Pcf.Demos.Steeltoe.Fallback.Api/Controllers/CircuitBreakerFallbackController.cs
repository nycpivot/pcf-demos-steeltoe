using Microsoft.AspNetCore.Mvc;
using Pcf.Demos.Steeltoe.Api.Fallback.Domain;

namespace Pcf.Demos.Steeltoe.Fallback.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/circuit-breaker-fallback")]
    public class CircuitBreakerFallbackController : Controller
    {
        public IActionResult Get()
        {
            var serviceDetails = new ServiceDetails()
            {
                WorkingSet64 = "1",
                TotalProcessorTime = "1"
            };

            return Ok(serviceDetails);
        }
    }
}