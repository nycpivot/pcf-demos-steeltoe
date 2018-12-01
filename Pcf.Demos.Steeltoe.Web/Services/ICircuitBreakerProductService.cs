using Pcf.Demos.Steeltoe.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pcf.Demos.Steeltoe.Web.Services
{
    public interface ICircuitBreakerProductService
    {
        Task<IEnumerable<ProductViewModel>> GetServiceDetails();

        Task<IEnumerable<ProductViewModel>> GetServiceDetailsFallback();
    }
}