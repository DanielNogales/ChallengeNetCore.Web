using ChallengeNetCore.Web.Business;
using ChallengeNetCore.WebClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeNetCore.WebClient.Controllers
{
    public class HomeController : Controller
    {
        [BindProperty(SupportsGet = true)]
        public double Price { get; set; }

        public IActionResult Index()
        {
            var salesService = new SalesService();
            var productList = salesService.GetProducts(Price);

            return View(productList);
        }

        [Route("Home/ProductsList/{price?}")]
        public ViewResult ProductsList(int? price)
        {
            var salesService = new SalesService();
            var productList = salesService.GetProducts(price);
            
            return View(productList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
