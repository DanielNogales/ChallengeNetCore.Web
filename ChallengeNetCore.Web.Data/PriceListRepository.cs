using ChallengeNetCore.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChallengeNetCore.Web.Data
{
    public class PriceListRepository
    {
        readonly ChallengeNetCoreDbContext challengeNetCoreDbContext;

        public PriceListRepository()
        {
            challengeNetCoreDbContext = new ChallengeNetCoreDbContext();
        }

        public DbSet<PriceList> GetPriceLists()
        {
            return challengeNetCoreDbContext.PriceLists; 
        }

        public void AddPriceLists(List<PriceList> priceLists)
        {
            foreach (var priceList in priceLists)
            {
                AddPriceList(priceList);
            }
        }

        public void AddPriceList(PriceList priceList)
        {
            //if (priceList.Product.CategoryId > 0)
            //    challengeNetCoreDbContext.Entry(priceList.Product.Category).State == EntityState.Unchanged;

            challengeNetCoreDbContext.Add(priceList);
            challengeNetCoreDbContext.SaveChanges();
        }
    }
}
