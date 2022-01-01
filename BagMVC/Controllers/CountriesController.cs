using ApiCountryLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace BagMVC.Controllers
{
    public class CountriesController : BaseApiController
    {
        public CountriesController(IConfiguration config) : base(config)
        {
        }

        public async Task<IActionResult> Index()
        {
            var countries = await client.GetCountryCurrencies();
            return View(countries);
        }

        public async Task<IActionResult> Details(int id)
        {
            var countries = await client.GetCountryCurrencies();
            return View(countries.FirstOrDefault(c => c.CountryId == id));
        }
    }
}
