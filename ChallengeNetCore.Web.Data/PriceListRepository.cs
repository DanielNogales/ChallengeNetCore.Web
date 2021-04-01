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

        public DbSet<PriceList> Get()
        {
            return challengeNetCoreDbContext.PriceLists;
        }

        public void Add(PriceList priceList)
        {
            //challengeNetCoreDbContext.Add(priceList);
            //challengeNetCoreDbContext.SaveChanges();
            challengeNetCoreDbContext.Database.ExecuteSqlRaw($@"
INSERT INTO PriceLists (ProductId, Price, Date)
              VALUES ({priceList.Product.Id}, {priceList.Price}, '{priceList.Date.ToString("s")}')
");
        }
    }
}
