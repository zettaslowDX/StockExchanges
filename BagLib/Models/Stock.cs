using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagLib.Models
{
    public class Stock
    {
        public int StockId { get; protected set; }

        public string Name { get; protected set; }

        /// <summary>
        /// Abreviatura
        /// </summary>
        public string Ticket { get; protected set; }

        public int MarketId { get; protected set; }

        public double MarketShare { get; protected set; }

        public double MarketOpenShare { get; protected set; }

        /// <summary>
        /// Si sube o baja
        /// </summary>
        public bool? Trend
        {
            get
            {
                return (MarketOpenShare == MarketShare) ? null : ((MarketOpenShare < MarketShare) ? true : false);
            }
        }

        public bool? Trend2 => ((MarketOpenShare == MarketShare) ? null : ((MarketOpenShare < MarketShare) ? true : false));

        public Stock(string name, string ticket, int marketId)
        {
            Name = name;
            Ticket = ticket;
            MarketId = marketId;
        }
    }
}
