using Microsoft.EntityFrameworkCore;
using Pcf.Demos.Steeltoe.Connectors.SqlServer.Customers.Api.Domain;
using System;

namespace Pcf.Demos.Steeltoe.Connectors.SqlServer.Customers.Api
{
    public class CustomersContext : DbContext
    {
        public CustomersContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<WishList> WishList { get; set; }

        //public void GetIt()
        //{
        //    Console.Write("CONNECTION STRING: " + this.Database.GetDbConnection().ConnectionString);
        //}
    }
}