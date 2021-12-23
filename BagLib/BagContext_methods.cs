using BagLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagLib
{
    public partial class BagContext : DbContext
    {
        public async Task<Currency> GetCurrencyAsync(string code)
        {
            return await Currency.FirstOrDefaultAsync(d => d.Code == code);
        }

        public async Task<Currency> InsertCurrencyAsync(Currency currency)
        {
            Add(currency);

            await SaveChangesAsync();

            return currency;
        }

        public async Task<Country> GetCountryByNameAsync(string name)
        {
            return await Country
                .Include(d=>d.Currencies)
                .FirstOrDefaultAsync(d => d.Name == name || d.ApiName == name);
        }

        public async Task<Country> GetCountryAsync(int? id)
        {
            return await Country
                .Include(d => d.Currencies)
                .FirstOrDefaultAsync(m => m.CountryId == id);
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            return await Country
                            .Include(d => d.Currencies)
                            .ToListAsync();
        }

        public async Task<Country> InsertCountryAsync(Country country)
        {
            Add(country);

            await SaveChangesAsync();

            return country;
        }

        public async Task<Stock> GetStockAsync(string symbol)
        {
            return await Stock.FirstOrDefaultAsync(d => d.Ticket == symbol);
        }

        public async Task<Stock> InsertStockAsync(Stock stock)
        {
            Add(stock);

            await SaveChangesAsync();

            return stock;
        }

        public async Task<Market> GetMarketByNameAsync(string name)
        {
            return await Market.FirstOrDefaultAsync(d => d.Name == name);
        }

        public async Task<Market> InsertMarketAsync(Market Market)
        {
            Add(Market);

            await SaveChangesAsync();

            return Market;
        }


    }
}
