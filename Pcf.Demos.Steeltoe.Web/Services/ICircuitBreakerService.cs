using Pcf.Demos.Steeltoe.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pcf.Demos.Steeltoe.Web.Services
{
    public interface ICircuitBreakerService
    {
        Task<IEnumerable<ProductViewModel>> GetCustomerWishlist();
        void Crash();
    }
}