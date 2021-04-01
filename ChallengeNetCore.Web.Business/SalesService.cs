using ChallengeNetCore.Web.Data;
using ChallengeNetCore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeNetCore.Web.Business
{
    public class SalesService : ISalesService
    {
        readonly IStockService _stockService;

        public SalesService(IStockService stockService)
        {
            _stockService = stockService;
        }

        public void AddPriceList(PriceList priceList)
        {
            var priceListRep = new PriceListRepository();
            var category = _stockService.GetCategoryByName(priceList.Product.Category.Name);
            if (category == null)
            {
                var categoryAdd = new Category { Name = priceList.Product.Category.Name };
                var categoryRep = new CategoryRepository();
                category = categoryRep.Add(categoryAdd);
            }

            var product = _stockService.GetProductByName(priceList.Product.Name);
            if (product == null)
            {
                var productAdd = new Product { Name = priceList.Product.Name, Category = category };
                var productRep = new ProductRepository();
                product = productRep.Add(productAdd);
            }

            priceList.Product = product;
            priceListRep.Add(priceList);
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
            return _stockService.GetProducts();
        }

        List<PriceList> GetProductsGroupCategory(int? price)
        {
            var listCatUno = _stockService.GetProductsCategory("PRODUNO");
            var listCatDos = _stockService.GetProductsCategory("PRODDOS");

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
