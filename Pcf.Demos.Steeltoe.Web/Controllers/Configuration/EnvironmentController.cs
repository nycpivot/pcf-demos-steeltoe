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

            var applicationSettings = configuration["VCAP_APPLICATION"];
            var serviceSettings = configuration["VCAP_SERVICES"];

            ViewBag.ApplicationSettings = applicationSettings.Replace(
                "\"application_name\":\"pcf-demos-steeltoe-web\"", 
                "<b>\"application_name\":\"pcf-demos-steeltoe-web\"</b>");

            ViewBag.ServiceSettings = serviceSettings
                .Replace("\"p-config-server\":", "<b>\"p-config-server\"</b>:")
                .Replace("\"p-service-registry\":", "<b>\"p-service-registry\"</b>:")
                .Replace("\"p-circuit-breaker-dashboard\":", "<b>\"p-circuit-breaker-dashboard\"</b>:");

            return View();
        }
    }
}