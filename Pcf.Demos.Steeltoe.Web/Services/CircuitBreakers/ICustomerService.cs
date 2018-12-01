using Pcf.Demos.Steeltoe.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pcf.Demos.Steeltoe.Web.Services.CircuitBreakers
{
    public interface ICustomerService
    {
        Task<IEnumerable<ProductViewModel>> GetWishlist();

        Task<IEnumerable<ProductViewModel>> GetWishlistFallback();
    }
}