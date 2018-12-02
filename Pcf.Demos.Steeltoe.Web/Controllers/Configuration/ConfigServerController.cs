using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Pcf.Demos.Steeltoe.Web.Controllers.Configuration
{
    public class ConfigServerController : Controller
    {
        private readonly IConfiguration configuration;

        public ConfigServerController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.ConnectionString = configuration["ConnectionString"];
            ViewBag.UserName = configuration["UserName"];
            ViewBag.Password = configuration["Password"];

            return View();
        }
    }
}