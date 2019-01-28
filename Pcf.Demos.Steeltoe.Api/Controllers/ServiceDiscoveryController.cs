using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using System;

namespace Pcf.Demos.Steeltoe.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/service-discovery")]
    public class ServiceDiscoveryController : Controller
    {
        private readonly CloudFoundryApplicationOptions appOptions;

        public ServiceDiscoveryController(
            IOptions<CloudFoundryApplicationOptions> appOptions)
        {
            this.appOptions = appOptions.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(appOptions);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            Environment.Exit(-1);

            return NoContent();
        }
    }
}