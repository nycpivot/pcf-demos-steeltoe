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
                ViewData["AppId"] = appOptions.ApplicationId;
                ViewData["AppName"] = appOptions.ApplicationName;
                ViewData["URI"] = appOptions.ApplicationUris != null
                    && appOptions.ApplicationUris.Length > 0 ? appOptions.ApplicationUris[0] : "";

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