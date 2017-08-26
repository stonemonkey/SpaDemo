using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SpaDemo.Controllers.Countries
{
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly CountriesContext _dbContext;

        public CountriesController(CountriesContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<JsonResult> GetAllCountries()
        {
            return Json(await _dbContext.Countries.ToArrayAsync());
        }
    }
}