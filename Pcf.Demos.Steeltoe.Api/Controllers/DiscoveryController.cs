using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace Pcf.Demos.Steeltoe.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/discovery")]
    public class DiscoveryController : Controller
    {
        private readonly CloudFoundryApplicationOptions appOptions;

        public DiscoveryController(
            IOptions<CloudFoundryApplicationOptions> appOptions)
        {
            this.appOptions = appOptions.Value;
        }

        public IActionResult Get()
        {
            return Ok(appOptions);
        }
    }
}