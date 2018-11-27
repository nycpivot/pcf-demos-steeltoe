using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Pcf.Demos.Steeltoe.Web.Controllers.Configuration
{
    public class AppSettingsController : Controller
    {
        private readonly IConfiguration configuration;

        public AppSettingsController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["Setting"] = configuration["Setting"];

            return View();
        }
    }
}