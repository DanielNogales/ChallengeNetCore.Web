using ChallengeNetCore.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChallengeNetCore.Web.Data
{

    public class CategoryRepository
    {
        readonly ChallengeNetCoreDbContext challengeNetCoreDbContext;

        public CategoryRepository()
        {
            challengeNetCoreDbContext = new ChallengeNetCoreDbContext();
        }

        public DbSet<Category> GetCategories()
        {
            return challengeNetCoreDbContext.Categories;
        }

        public Category Get(string categoryName)
        {
            return challengeNetCoreDbContext.Categories
                .FirstOrDefault(c => c.Name == categoryName);
        }

        public Category Get(int id)
        {
            return challengeNetCoreDbContext.Categories
                .FirstOrDefault(c => c.Id == id);
        }

        public Category Add(Category category)
        {
            //challengeNetCoreDbContext.Add(category);
            //challengeNetCoreDbContext.SaveChanges();
            challengeNetCoreDbContext.Database.ExecuteSqlRaw($@"
INSERT INTO Categories (Name)
                VALUES ('{category.Name}')
");
            return Get(category.Name);
        }
    }
}
