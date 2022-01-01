using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace BagMVC.Controllers
{
    public class CurrenciesController : BaseApiController
    {
        public CurrenciesController(IConfiguration config) : base(config)
        {
        }
        public async Task<IActionResult> Index()
        {
            var currencies = await client.GetCurrencies();
            return View(currencies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var currencies = await client.GetCurrencies();
            return View(currencies.FirstOrDefault(c => c.CurrencyId == id));
        }
    }
}
