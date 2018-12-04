using Microsoft.EntityFrameworkCore;
using Pcf.Demos.Steeltoe.Domain.Customers;
using System;

namespace Pcf.Demos.Steeltoe.Connectors.SqlServer.Customers.Api
{
    public class CustomersContext : DbContext
    {
        public CustomersContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("CONNECTION STRING " + this.Database.GetDbConnection().ConnectionString);

            //this.Database.GetDbConnection().ConnectionString 
            //    = "Server=saffron.arvixe.com;Database=PivotalCustomers;User Id=nycpivot; Password=P@$$w0rd#01;";
        }

        public DbSet<Product> WishList { get; set; }

        //public void GetIt()
        //{
        //    Console.Write("CONNECTION STRING: " + this.Database.GetDbConnection().ConnectionString);
        //}
    }
}