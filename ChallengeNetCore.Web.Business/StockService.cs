using ChallengeNetCore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChallengeNetCore.Web.Business
{
    public class StockService
    {
        public List<PriceList> GetProductsCategory(string categoryName)
        {
            var pList = GetProductsFromDb()
                .Where(pl => pl.Product.Category.Name == categoryName)
                .OrderByDescending(p => p.Price).ToList();

            return pList;
        }

        public List<PriceList> GetProducts()
        {
            return GetProductsFromDb();
        }

        List<PriceList> GetProductsFromDb()
        {
            var pList = new List<PriceList>();
            var catUno = new Category() { Id = 1, Name = "PRODUNO" };
            var catDos = new Category() { Id = 2, Name = "PRODDOS" };

            //Ejemplo 1
            pList.Add(new PriceList()
            {
                Id = 1,
                Price = 10,
                Product = new Product() { Name = "ProductoA", Category = catDos },
                Date = new DateTime(2019, 10, 25)
            });
            pList.Add(new PriceList()
            {
                Id = 2,
                Price = 60,
                Product = new Product() { Name = "ProductoB", Category = catUno },
                Date = new DateTime(2019, 10, 21)
            });
            pList.Add(new PriceList()
            {
                Id = 3,
                Price = 5,
                Product = new Product() { Name = "ProductoC", Category = catDos },
                Date = new DateTime(2019, 10, 22)
            });
            pList.Add(new PriceList()
            {
                Id = 4,
                Price = 5,
                Product = new Product() { Name = "ProductoD", Category = catUno },
                Date = new DateTime(2019, 10, 29)
            });
            pList.Add(new PriceList()
            {
                Id = 5,
                Price = 15,
                Product = new Product() { Name = "ProductoE", Category = catDos },
                Date = new DateTime(2019, 09, 11)
            });

            //Ejemplo 2
            pList.Add(new PriceList()
            {
                Id = 10,
                Price = 50,
                Product = new Product() { Name = "ProductoA2", Category = catDos },
                Date = new DateTime(2019, 10, 25)
            });
            pList.Add(new PriceList()
            {
                Id = 20,
                Price = 44,
                Product = new Product() { Name = "ProductoB2", Category = catUno },
                Date = new DateTime(2019, 10, 21)
            });
            pList.Add(new PriceList()
            {
                Id = 30,
                Price = 40,
                Product = new Product() { Name = "ProductoC2", Category = catDos },
                Date = new DateTime(2019, 10, 22)
            });
            pList.Add(new PriceList()
            {
                Id = 40,
                Price = 5,
                Product = new Product() { Name = "ProductoD2", Category = catUno },
                Date = new DateTime(2019, 10, 29)
            });
            pList.Add(new PriceList()
            {
                Id = 50,
                Price = 15,
                Product = new Product() { Name = "ProductoE2", Category = catDos },
                Date = new DateTime(2019, 09, 11)
            });
            return pList;
        }

    }
}
