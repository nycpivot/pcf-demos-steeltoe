using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pcf.Demos.Steeltoe.Api.Services
{
    public interface ICircuitBreakerCustomerWishlistService
    {
        Task<IEnumerable<Domain.Customers.Product>> GetWishlist();

        Task<IEnumerable<Domain.Products.Product>> GetProducts();
    }
}