using ApiStocksLib;
using BagLib;
using BagLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace BagMVC.Controllers
{
    public abstract class _BaseController : Controller
    {
        protected readonly BagContext _context;

        protected IConfiguration _configuration;

        protected int CurrentUserId { get; set; } = 1;


        public _BaseController(BagContext context)
        {
            _context = context;
        }

        public _BaseController(BagContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        protected ApiStockClient GetStockApiClient()
        {
            return new(_configuration["ApiStocksUrl"], _configuration["ApiKeys:Stocks"]);
        }

        //protected async Task<Stock> CheckAndCreate(Company company)
        protected async Task<Stock> CheckAndCreate(string ticket)
        {
            // 1: Compruebo si Existe
            Stock stock = await _context.GetStockAsync(ticket);

            if (stock == null)
            {
                //2 : Si no exite, lo busco en el API
                var stockClient = GetStockApiClient();

                var company = await stockClient.GetCompany(ticket);

                if ( company!=null )
                {
                    //3 : Ver si existe el mercado
                    var market = await _context.GetMarketByNameAsync(company.Exchange);

                    if ( market == null )
                    {
                        // Si no existe lo creo, obtengo el país de mi BD
                        Country country = await _context.GetCountryByNameAsync(company.Country);

                        Currency currency = await _context.GetCurrencyAsync(company.Currency);

                        market = new(company.Exchange, "", country.CountryId, currency.CurrencyId);

                        market = await _context.InsertMarketAsync(market);
                    }

                    // Inserto la acción
                    stock = new(company.Name, company.Symbol, market.MarketId);

                    stock = await _context.InsertStockAsync(stock);
                }
            }       

            return stock;
        }
    }
}
