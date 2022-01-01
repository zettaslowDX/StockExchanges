using ApiCountryLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BagMVC.Controllers
{
    public class BaseApiController : Controller
    {
        internal ApiCountryClient client;
        public BaseApiController(IConfiguration config)
        {
            client = new ApiCountryClient(config.GetConnectionString("DbJson"));
        }
    }
}
