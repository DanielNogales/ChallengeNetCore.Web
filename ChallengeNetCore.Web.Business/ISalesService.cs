using ChallengeNetCore.Web.Models;
using System.Collections.Generic;

namespace ChallengeNetCore.Web.Business
{
    public interface ISalesService
    {
        List<PriceList> GetProducts();
        List<PriceList> GetProducts(double? price);
    }
}