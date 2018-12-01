using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pcf.Demos.Steeltoe.Web.Services.Discovery;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using System.Collections.Generic;
using System.Linq;

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

            var usedIPs = new List<string>();
            foreach (var ip in HttpContext.Session.Keys)
            {
                if (ip != serviceOptions.InstanceIP)
                {
                    usedIPs.Add(ip);
                }
            }

            ViewBag.UsedIPs = usedIPs;
            
            HttpContext.Session.SetString(serviceOptions.InstanceIP, serviceOptions.InstanceIP);

            ViewBag.ServiceIP = serviceOptions.InstanceIP;
            //ViewBag.ServerName = serviceOptions.ServerName;

            return View();
        }
    }
}