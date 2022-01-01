using BagLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiCountryLib
{
    public class ApiCountryClient
    {
        public ApiCountryClient(string url)
        {
            this.mUrl = url;
        }

        protected string mUrl { get; set; }


        protected HttpClient client { get; set; }

        private string GetRelative(string s)
        {
            return "/zettaslowDX/StockExchanges/" + s;
        }

        public async Task<List<Country>> GetCountries()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(this.mUrl);

            // Para reutilizar código sin embeber el número de versión:
            //var response = await client.GetAsync("/v2/all");

            var response = await client.GetAsync( GetRelative("Countries") );


            if ( response.IsSuccessStatusCode )
            {
                // Ya no hace falta, estoy convirtiendo el json directamente a mis clases
                //string chorizoJson = await response.Content.ReadAsStringAsync();

                return await response.Content.ReadAsAsync<List<Country>>();
            }
            else
            {

            }

            return null;
        }
        public async Task<List<Currency>> GetCurrencies()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(this.mUrl);

            // Para reutilizar código sin embeber el número de versión:
            //var response = await client.GetAsync("/v2/all");

            var response = await client.GetAsync(GetRelative("Currencies"));


            if (response.IsSuccessStatusCode)
            {
                // Ya no hace falta, estoy convirtiendo el json directamente a mis clases
                //string chorizoJson = await response.Content.ReadAsStringAsync();

                return await response.Content.ReadAsAsync<List<Currency>>();
            }
            else
            {

            }

            return null;
        }
        public async Task<List<Country>> GetCountryCurrencies()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(this.mUrl);

            // Para reutilizar código sin embeber el número de versión:
            //var response = await client.GetAsync("/v2/all");

            var response = await client.GetAsync(GetRelative("/CountryCurrency"));


            if (response.IsSuccessStatusCode)
            {
                // Ya no hace falta, estoy convirtiendo el json directamente a mis clases
                //string chorizoJson = await response.Content.ReadAsStringAsync();

                return await response.Content.ReadAsAsync<List<Country>>();
            }
            else
            {

            }

            return null;
        }
    }
}
