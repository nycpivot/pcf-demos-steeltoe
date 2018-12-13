using Microsoft.AspNetCore.Mvc;
using Pcf.Demos.Steeltoe.Connectors.Redis.Products.Api.Services;

namespace Pcf.Demos.Steeltoe.Connectors.Redis.Products.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Get()
        {
            var products = productsService.GetProducts();

            return Ok(products);
        }
    }
}