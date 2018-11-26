
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Pcf.Demos.Steeltoe.Web.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly IConfiguration config;

        public ConfigurationController(IConfiguration config)
        {
            this.config = config;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = config["message"];

            return View();
        }
    }
}