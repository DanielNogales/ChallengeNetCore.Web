using ChallengeNetCore.Web.Models;
using System.Collections.Generic;

namespace ChallengeNetCore.Web.Business
{
    public interface IStockService
    {
        List<PriceList> GetProducts();
        List<PriceList> GetProductsCategory(string categoryName);
    }
}