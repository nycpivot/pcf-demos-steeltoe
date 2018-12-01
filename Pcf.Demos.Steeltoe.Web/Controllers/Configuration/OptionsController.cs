using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using System;

namespace Pcf.Demos.Steeltoe.Web.Controllers.Configuration
{
    public class OptionsController : Controller
    {
        private readonly CloudFoundryApplicationOptions appOptions;
        private readonly CloudFoundryServicesOptions serviceOptions;

        public OptionsController(
            IOptions<CloudFoundryApplicationOptions> appOptions,
            IOptions<CloudFoundryServicesOptions> serviceOptions)
        {
            this.appOptions = appOptions.Value;
            this.serviceOptions = serviceOptions.Value;
        }

        public IActionResult Index()
        {
            try
            {
                //read app settings
                ViewBag.ApplicationId = appOptions.ApplicationId;
                ViewBag.ApplicationName = appOptions.ApplicationName;
                ViewBag.Uri = appOptions.ApplicationUris != null
                    && appOptions.ApplicationUris.Length > 0 ? appOptions.ApplicationUris[0] : "";
                ViewBag.ApplicationVersion = appOptions.ApplicationVersion;
                ViewBag.CloudFoundryApi = appOptions.CF_Api;
                ViewBag.DiskLimit = appOptions.DiskLimit;
                ViewBag.InstanceIndex = appOptions.InstanceIndex;
                ViewBag.InstanceId = appOptions.InstanceId;
                ViewBag.InstanceIp = appOptions.InstanceIP;
                ViewBag.InternalIp = appOptions.InternalIP;
                ViewBag.Limits = appOptions.Limits;
                ViewBag.MemoryLimit = appOptions.MemoryLimit;
                ViewBag.Name = appOptions.Name;
                ViewBag.Port = appOptions.Port;
                ViewBag.SpaceId = appOptions.SpaceId;
                ViewBag.SpaceName = appOptions.SpaceName;
                ViewBag.Start = appOptions.Start;
                ViewBag.Uris = appOptions.Uris;
                ViewBag.Version = appOptions.Version;

                //read first service settings
                if (serviceOptions.ServicesList != null && serviceOptions.ServicesList.Count > 0)
                {
                    var serviceOption = serviceOptions.ServicesList[0];

                    ViewData["ServiceLabel"] = serviceOption.Label;
                    ViewData["ServiceName"] = serviceOption.Name;

                    if (serviceOption.Credentials != null && serviceOption.Credentials.Count > 0)
                    {
                        ViewData["ClientId"] = serviceOption.Credentials["client_id"];
                        ViewData["ClientSecret"] = serviceOption.Credentials["client_secret"];
                        ViewData["ServiceUri"] = serviceOption.Credentials["uri"];
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }

            return View();
        }
    }
}