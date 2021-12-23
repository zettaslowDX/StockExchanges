using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagLib.Models
{
    public class BagUser
    {
        public int BagUserId { get; set; }

        public string Name { get; set; }


        public ICollection<MyStock> MyStocks { get; set; }
    }
}
