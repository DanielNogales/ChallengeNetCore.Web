using ChallengeNetCore.Web.Business;
using ChallengeNetCore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeNetCore.Web.Controller
{
    [Route("/[controller]")]
    public class SalesController : ControllerBase
    {
        /// <summary>
        /// Devuelve una lista de productos
        /// agrupados por categoría (PRODUNO, PRODDOS)
        /// en base al presupuesto ingresado.
        /// </summary>
        /// <param name="presupuesto"></param>
        /// <returns name="List<PriceList>"></returns>
        [HttpGet("Get/{presupuesto}")]
        public List<PriceList> Get(int presupuesto)
        {
            var salesService = new SalesService();
            return salesService.GetProducts(presupuesto);
        }

        /// <summary>
        /// Devuelve una lista de todos los productos.
        /// </summary>
        /// <returns name="List<PriceList>"></returns>
        [HttpGet("Get")]
        public List<PriceList> Get()
        {
            var salesService = new SalesService();
            return salesService.GetProducts();
        }
    }
}
