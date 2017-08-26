using Microsoft.EntityFrameworkCore;

namespace SpaDemo.Controllers.Customers
{
    public class CustomersContext : DbContext
    {
        public CustomersContext(DbContextOptions<CustomersContext> options) 
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}