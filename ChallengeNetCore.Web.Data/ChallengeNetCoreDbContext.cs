using ChallengeNetCore.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChallengeNetCore.Web.Data
{
    public class ChallengeNetCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=W10ROCKBALL\SQLEXPRESS;Encrypt=False;Initial Catalog=ChallengeNetCore;Integrated Security=True;User ID=W10ROCKBALL\nogal");
        }

        public ChallengeNetCoreDbContext()
        {
        }

        //public ChallengeNetCoreDbContext(DbContextOptions<ChallengeNetCoreDbContext> options)
        //    : base(options)
        //{ }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
    }
}
