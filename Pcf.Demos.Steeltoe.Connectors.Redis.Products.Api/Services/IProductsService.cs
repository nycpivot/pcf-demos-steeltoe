using Pcf.Demos.Steeltoe.Domain.Products;
using System.Collections.Generic;

namespace Pcf.Demos.Steeltoe.Connectors.Redis.Products.Api.Services
{
    public interface IProductsService
    {
        IEnumerable<Product> GetProducts();
    }
}