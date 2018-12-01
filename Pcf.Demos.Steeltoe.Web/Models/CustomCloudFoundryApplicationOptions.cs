using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace Pcf.Demos.Steeltoe.Web.Models
{
    public class CustomCloudFoundryApplicationOptions
        : CloudFoundryApplicationOptions
    {
        public string ServerName { get; set; }
    }
}