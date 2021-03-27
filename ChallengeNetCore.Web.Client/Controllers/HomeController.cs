using AutoMapper;
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
        private readonly ISalesService _salesService;
        private readonly IMapper _mapper; 

        public HomeController(ISalesService salesService, IMapper mapper)
        {
            
            _salesService = salesService;
            _mapper = mapper;
        }

        [BindProperty(SupportsGet = true)]
        public double Price { get; set; }

        public IActionResult Index()
        {
            var productList = _salesService.GetProducts(Price);
            return View(productList);
        }


        [Route("Home/ProductsList/{price?}")]
        public ViewResult ProductsList(int? price)
        {
            var productList = _salesService.GetProducts(price);
            return View(productList);
        }


        [HttpGet]
        public IActionResult AddPriceList()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddPriceList(PriceListDto piceListDto)
        {
            PriceList priceList = GetPriceListFromDto(piceListDto);
            return RedirectToAction("Index");
        }

        PriceList GetPriceListFromDto(PriceListDto piceListDto)
        {
            var priceList = _mapper.Map<PriceList>(piceListDto);
            return priceList;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
