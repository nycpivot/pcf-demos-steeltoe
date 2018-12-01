using Microsoft.AspNetCore.Mvc;
using Pcf.Demos.Steeltoe.Web.Services;

namespace Pcf.Demos.Steeltoe.Web.Controllers
{
    public class CircuitBreakerController : Controller
    {
        private readonly CircuitBreakerCommand circuitBreakerCommand;

        public CircuitBreakerController(CircuitBreakerCommand circuitBreakerCommand)
        {
            this.circuitBreakerCommand = circuitBreakerCommand;
        }

        public IActionResult Index()
        {
            var serviceDetailsModel = circuitBreakerCommand.GetServiceDetails().Result;

            //ViewBag.WorkingSet64 = serviceDetailsModel.WorkingSet64;
            //ViewBag.TotalProcessorTime = serviceDetailsModel.TotalProcessorTime;

            return View();
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var serviceDetailsModel = circuitBreakerCommand.GetServiceDetails().Result;

        //    ViewBag.WorkingSet64 = serviceDetailsModel.WorkingSet64;
        //    ViewBag.TotalProcessorTime = serviceDetailsModel.TotalProcessorTime;

        //    return Ok(serviceDetailsModel);
        //}
    }
}