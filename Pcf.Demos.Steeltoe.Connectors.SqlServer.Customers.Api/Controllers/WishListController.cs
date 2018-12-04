using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Pcf.Demos.Steeltoe.Connectors.SqlServer.Customers.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/wishlist")]
    public class WishListController : Controller
    {
        private readonly CustomersContext context;

        public WishListController(CustomersContext context)
        {
            this.context = context;
        }

        public IActionResult Get()
        {
            var wishlist = context.WishList.ToList();

            return Ok(wishlist);
        }
    }
}