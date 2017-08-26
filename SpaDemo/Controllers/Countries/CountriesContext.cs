using Microsoft.EntityFrameworkCore;

namespace SpaDemo.Controllers.Countries
{
    public class CountriesContext : DbContext
    {
        public CountriesContext(DbContextOptions<CountriesContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
    }
}