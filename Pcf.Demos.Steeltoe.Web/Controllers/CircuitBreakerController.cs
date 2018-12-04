using Microsoft.AspNetCore.Mvc;
using Pcf.Demos.Steeltoe.Web.Services;

namespace Pcf.Demos.Steeltoe.Web.Controllers
{
    public class CircuitBreakerController : Controller
    {
        private readonly ICircuitBreakerService circuitBreakerService;

        public CircuitBreakerController(ICircuitBreakerService circuitBreakerService)
        {
            this.circuitBreakerService = circuitBreakerService;
        }

        public IActionResult Index()
        {
            ViewBag.Products = circuitBreakerService
                .GetCustomerWishlist().Result;

            return View();
        }
    }
}