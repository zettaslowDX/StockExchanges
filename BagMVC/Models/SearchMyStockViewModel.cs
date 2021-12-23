using ApiStocksLib;
using System.ComponentModel.DataAnnotations;

namespace BagMVC.Models
{
    public class SearchMyStockViewModel
    {
        [Required]
        public string Text { get; set; }

        public RootBestMatches RootBestMatches { get; set; }
    }
}
