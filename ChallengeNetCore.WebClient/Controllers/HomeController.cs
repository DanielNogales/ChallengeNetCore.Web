using ChallengeNetCore.Web.Business;
using ChallengeNetCore.Web.Client.Models;
using ChallengeNetCore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeNetCore.Web.Client.Controllers
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

        [HttpGet]
        public IActionResult AddPriceList()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddPriceList(PriceListDto piceList)
        {
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
