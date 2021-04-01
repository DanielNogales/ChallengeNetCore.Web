using ChallengeNetCore.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChallengeNetCore.Web.Data
{
    public class ProductRepository
    {
        readonly ChallengeNetCoreDbContext challengeNetCoreDbContext;

        public ProductRepository()
        {
            challengeNetCoreDbContext = new ChallengeNetCoreDbContext();
        }

        public DbSet<Product> Get()
        {
            return challengeNetCoreDbContext.Products;
        }

        public Product Get(string productName)
        {
            return challengeNetCoreDbContext.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Name == productName);
        }

        public Product Get(int id)
        {
            return challengeNetCoreDbContext.Products
                .Include(p => p.Category)
                .FirstOrDefault(c => c.Id == id);
        }

        public Product Add(Product product)
        {
            //challengeNetCoreDbContext.Add(product);
            //challengeNetCoreDbContext.SaveChanges();
            challengeNetCoreDbContext.Database.ExecuteSqlRaw($@"
INSERT INTO Products (Name, CategoryId)
              VALUES ('{product.Name}', {product.Category.Id})
");
            return Get(product.Name);
        }
    }
}
