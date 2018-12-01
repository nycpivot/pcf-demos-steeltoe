using Steeltoe.Extensions.Configuration.CloudFoundry;
using System.Threading.Tasks;

namespace Pcf.Demos.Steeltoe.Web.Services.Discovery
{
    public interface IServiceDiscoveryService
    {
        Task<CloudFoundryApplicationOptions> GetServiceDetails();
    }
}