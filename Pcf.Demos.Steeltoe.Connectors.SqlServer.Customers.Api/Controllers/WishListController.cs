using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            //context.GetIt();

            var wishlist = context.WishList.ToList();

            return Ok(wishlist);
        }
    }
}