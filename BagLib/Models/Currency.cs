using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagLib.Models
{
    public class Currency
    {
        public Currency(string code, string name, string symbol)
        {
            Code = code;
            Name = name;
            Symbol = symbol;

            Countries = new HashSet<Country>();
            Markets = new HashSet<Market>();
        }

        public int CurrencyId { get; set; } 

        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }


        public ICollection<Country> Countries { get; set; }

        public ICollection<Market> Markets { get; set; }
    }
}
