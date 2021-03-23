using ChallengeNetCore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeNetCore.Web.Business
{
    public class SalesService
    {
        public List<PriceList> GetProducts(int? price)
        {
            if (price == null)
                return GetProducts();

            if (price <= 0)
                return new List<PriceList>();

            if (price > 1_000_000)
                return new List<PriceList>();

            List<PriceList> pList = GetProductsGroupCategory(price);
            return pList;
        }

        public List<PriceList> GetProducts()
        {
            var stkService = new StockService();
            return stkService.GetProducts();
        }

        class ElementsFromCategory
        {
            public int IdCatUno { get; set; }
            public int IdCatDos { get; set; }
            public int TotalPrice { get; set; }
            public int Diff { get; set; }
        }

        List<PriceList> GetProductsGroupCategory(int? price)
        {
            var stkService = new StockService();
            var listCatUno = stkService.GetProductsCategory("PRODUNO");
            var listCatDos = stkService.GetProductsCategory("PRODDOS");

            var cartesianConcat = (from a in listCatUno
                                   from b in listCatDos
                                   select new ElementsFromCategory()
                                   {
                                       IdCatUno = a.Id,
                                       IdCatDos = b.Id,
                                       TotalPrice = a.Price + b.Price,
                                       Diff = (a.Price + b.Price) - price ?? 0,
                                   })
                                   .Where(p => p.TotalPrice <= price)
                                   .OrderByDescending(p => p.Diff)
                                   .Take(1)
                                   .ToList();

            var productsGroupCategory = new List<PriceList>();
            if (cartesianConcat.Count() > 0)
            {
                productsGroupCategory.Add(listCatUno
                .Where(p => p.Id == cartesianConcat.FirstOrDefault().IdCatUno)
                .FirstOrDefault());

                productsGroupCategory.Add(listCatDos
                    .Where(p => p.Id == cartesianConcat.FirstOrDefault().IdCatDos)
                    .FirstOrDefault());
            }
            return productsGroupCategory;
        }
    }
}
