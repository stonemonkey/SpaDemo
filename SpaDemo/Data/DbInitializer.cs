using System.Linq;
using SpaDemo.Controllers.Customers;

namespace SpaDemo.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CustomersContext context)
        {
            context.Database.EnsureCreated();

            if (context.Countries.Any())
            {
                return;
            }

            var countries = new[]
            {
                new Country { Name= "Sweden" },
                new Country { Name= "Norway" },
                new Country { Name= "Finland" },
                new Country { Name= "Great Britain" },
                new Country { Name= "Danemark" },
                new Country { Name= "Belgium" },
                new Country { Name= "Netherland" },
                new Country { Name= "Germany" },
                new Country { Name= "Spain" },
                new Country { Name= "Italy" },
            };
            foreach (var country in countries)
            {
                context.Countries.Add(country);
            }
            context.SaveChanges();
        }
    }
}
