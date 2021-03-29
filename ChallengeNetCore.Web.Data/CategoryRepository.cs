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

        public Category GetCategory(string categoryName)
        {
            return challengeNetCoreDbContext.Categories.FirstOrDefault(c => c.Name == categoryName);
        }
    }
}
