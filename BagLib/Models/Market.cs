using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagLib.Models
{
    public class Market
    {
        public int MarketId { get; protected set; }


        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; protected set; }


        public string Description { get; protected set; }

        public int CountryId {  get; protected set; }

        public Country Country { get; protected set; }


        public short TimeZone { get; protected set; }


        public int CurrencyId { get; protected set; }

        public Currency Currency { get; set; }

        public ICollection<Stock> Stocks { get; set; }

        public Market( string name, string description, int countryId, int currencyId, short timeZone = 0)
        {
            Name = name;
            Description = description;
            CountryId = countryId;
            CurrencyId = currencyId;

            TimeZone = timeZone;

            Stocks = new HashSet<Stock>();
        }

    }
}
