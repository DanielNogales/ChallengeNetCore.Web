using NUnit.Framework;
using ChallengeNetCore.Web.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ChallengeNetCore.Web.Business.Tests
{
    [TestFixture()]
    public class SalesServiceTests
    {
        IStockService _stockService;
        ISalesService _salesService;

        [OneTimeSetUp]
        public void Setup()
        {
            _stockService = new StockService();
            _salesService = new SalesService(_stockService);
        }
        
        [TestCase(-1)]
        [TestCase(-5_000)]
        [TestCase(-1_000_000)]
        [TestCase(2_000_000)]
        public void GetProducts_InValidPriceTest(int price)
        {
            var products = _salesService.GetProductsFromPrice(price);

            Assert.AreEqual(0, products.Count);
        }

        [TestCase(10)]
        [TestCase(70)]
        [TestCase(60)]
        [TestCase(5_000)]
        [TestCase(1_000_000)]
        public void GetProducts_ValidPriceTest(int price)
        {
            var products = _salesService.GetProductsFromPrice(price);

            Assert.Greater(products.Count, 0);
            Assert.AreEqual(2, products.Count);

            var catUno = products.First().Product.Category;
            var catDos = products.Last().Product.Category;

            TestContext.WriteLine($"Presupuesto cliente: ${price}");
            TestContext.WriteLine($"Sugerido:");
            TestContext.WriteLine($"   {catUno.Id}, {catUno.Name} = {products.First().Product.Name} ${products.First().Price}");
            TestContext.WriteLine($"   {catDos.Id}, {catDos.Name} = {products.Last().Product.Name} ${products.Last().Price} ");

            Assert.AreNotEqual(catUno, catDos);
        }

        [Test()]
        public void GetProducts_ZeroPriceTest()
        {
            var products = _salesService.GetProductsFromPrice(0);

            Assert.Greater(products.Count, 0);
        }
    }
}