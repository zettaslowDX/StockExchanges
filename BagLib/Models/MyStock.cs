using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagLib.Models
{
    public class MyStock
    {
        public int MyStockId { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public double BuyPrice { get; set; }

        [Required]
        public DateTime BuyDate { get; set; }


        public int StockId { get; set; }

        public Stock Stock { get; set; }

        public int BagUserId { get; set; }

        public BagUser BagUser { get; set; }
    }
}
