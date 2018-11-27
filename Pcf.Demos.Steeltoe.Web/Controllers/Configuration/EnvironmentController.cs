using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Pcf.Demos.Steeltoe.Web.Controllers.Configuration
{
    public class EnvironmentController : Controller
    {
        private readonly IConfiguration configuration;

        public EnvironmentController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.ApplicationName = configuration["vcap:application:application_name"];

            ViewData["VCAP_APPLICATION"] = configuration["VCAP_APPLICATION"];
            ViewData["VCAP_SERVICES"] = configuration["VCAP_SERVICES"];

            return View();
        }
    }
}