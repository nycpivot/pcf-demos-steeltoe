using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Pcf.Demos.Steeltoe.Connectors.SqlServer.Products.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly ProductsContext context;

        public ProductsController(ProductsContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = context.Products.ToList();

            return Ok(products);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            Environment.Exit(-1);

            return NoContent();
        }
    }
}