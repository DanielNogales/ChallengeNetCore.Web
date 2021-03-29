using ChallengeNetCore.Web.Models;
using System.Collections.Generic;

namespace ChallengeNetCore.Web.Business
{
    public interface ISalesService
    {
        void AddPriceList(PriceList priceList);

        List<PriceList> GetProductsFromPrice(double? price);
    }
}