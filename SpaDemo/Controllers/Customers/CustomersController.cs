using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SpaDemo.Controllers.Customers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly CustomersContext _dbContext;

        public CustomersController(CustomersContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<JsonResult> GetAllCustomers()
        {
            return Json(await _dbContext.Customers.Include(x => x.Country).ToArrayAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            customer.CountryId = customer.Country.Id;
            customer.Country = null;

            try
            {
                _dbContext.Add(customer);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return StatusCode(503, customer); // Service Unavailable
            }

            return Created(Path.Combine(Request.GetDisplayUrl(), customer.Id.ToString()), customer);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var existingCustomer = _dbContext.Customers
                .AsNoTracking()
                .SingleOrDefault(x => x.Id == id);
            if (existingCustomer == null)
            {
                return NotFound(id);
            }

            try
            {
                _dbContext.Customers.Remove(existingCustomer);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return StatusCode(503, id); // Service Unavailable
            }

            return Ok();
        }
    }
}
