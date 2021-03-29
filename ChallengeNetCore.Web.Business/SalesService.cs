using ChallengeNetCore.Web.Data;
using ChallengeNetCore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeNetCore.Web.Business
{
    public class SalesService : ISalesService
    {
        public void AddPriceList(PriceList priceList)
        {
            var priceListRep = new PriceListRepository();
            priceListRep.AddPriceList(priceList);
        }

        public List<PriceList> GetProductsFromPrice(double? price)
        {
            if (price == null || price == 0)
                return GetAllProducts();


            if (price > 1_000_000)
                return new List<PriceList>();


            List<PriceList> pList = GetProductsGroupCategory(Convert.ToInt32(price));
            return pList;
        }
        
        List<PriceList> GetAllProducts()
        {
            var stkService = new StockService();
            return stkService.GetProducts();
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

        class ElementsFromCategory
        {
            public int Diff { get; set; }
            public int IdCatDos { get; set; }
            public int IdCatUno { get; set; }
            public int TotalPrice { get; set; }
        }
    }
}
