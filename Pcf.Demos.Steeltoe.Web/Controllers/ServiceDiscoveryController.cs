using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pcf.Demos.Steeltoe.Web.Services;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void Delete()
        {
            var bytes3 = Encoding.UTF8.GetBytes("3...");
            var bytes2 = Encoding.UTF8.GetBytes("2...");
            var bytes1 = Encoding.UTF8.GetBytes("1");

            Console.WriteLine("WARNING: THIS APP WILL SELF-DESTRUCT IN...");
            Console.OpenStandardError().Write(bytes3, 0, bytes3.Length);
            Console.OpenStandardError().Write(bytes2, 0, bytes2.Length);
            Console.OpenStandardError().Write(bytes1, 0, bytes1.Length);

            discoveryService.Crash();
        }
    }
}