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
        public ApiCountryClient(string url, int version)
        {
            this.mUrl = url;
            Version = version;
        }

        protected string mUrl { get; set; }

        protected int Version { get; set; }

        protected HttpClient client { get; set; }



        protected string GetRelative(string name)
        {
            return $"/v{Version}/{name}";
        }

        public async Task<List<Country>> GetCountries()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(this.mUrl);

            // Para reutilizar código sin embeber el número de versión:
            //var response = await client.GetAsync("/v2/all");

            var response = await client.GetAsync( GetRelative("all") );


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
    }
}
