using Microsoft.AspNetCore.Mvc;
using Pcf.Demos.Steeltoe.Api.Domain;
using System.Diagnostics;

namespace Pcf.Demos.Steeltoe.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/circuit-breaker")]
    public class CircuitBreakerController : Controller
    {
        public IActionResult Get()
        {
            var serviceDetails = new ServiceDetails();

            serviceDetails.WorkingSet64 = Process.GetCurrentProcess().WorkingSet64.ToString();
            serviceDetails.TotalProcessorTime = Process.GetCurrentProcess().TotalProcessorTime.TotalSeconds.ToString();

            return Ok(serviceDetails);
        }
    }
}