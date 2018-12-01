using Pcf.Demos.Steeltoe.Web.Models;
using System.Threading.Tasks;

namespace Pcf.Demos.Steeltoe.Web.Services.Discovery
{
    public interface IServiceDiscoveryService
    {
        Task<CustomCloudFoundryApplicationOptions> GetServiceDetails();
    }
}