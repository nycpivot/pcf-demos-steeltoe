using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pcf.Demos.Steeltoe.Web.Services;
using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace Pcf.Demos.Steeltoe.Web.Controllers
{
    public class ServiceDiscoveryController : Controller
    {
        private readonly CloudFoundryApplicationOptions appOptions;
        private readonly IServiceDiscoveryService discoveryService;

        public ServiceDiscoveryController(
            IOptions<CloudFoundryApplicationOptions> appOptions,
            IServiceDiscoveryService discoveryService)
        {
            this.appOptions = appOptions.Value;
            this.discoveryService = discoveryService;
        }

        public IActionResult Index()
        {
            ViewBag.ClientIP = appOptions.InstanceIP;

            var serviceOptions = discoveryService.GetServiceDetails().Result;

            ViewBag.ServiceIP = serviceOptions.InstanceIP;

            return View();
        }
    }
}