using Pcf.Demos.Steeltoe.Web.Models;
using System.Threading.Tasks;

namespace Pcf.Demos.Steeltoe.Web.Services
{
    public interface ICircuitBreakerService
    {
        Task<ServiceDetailsModel> GetServiceDetails();

        Task<ServiceDetailsModel> GetServiceDetailsFallback();
    }
}