using Microsoft.EntityFrameworkCore;

namespace Pcf.Demos.Steeltoe.Connectors.SqlServer.Products.Api
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}