using ChallengeNetCore.Web.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Diagnostics;

namespace ChallengeNetCore.Web.Data
{
    public class ChallengeNetCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string con = @"Data Source=W10ROCKBALL\SQLEXPRESS;Encrypt=False;Initial Catalog=ChallengeNetCore;Integrated Security=True;User ID=W10ROCKBALL\nogal";
            optionsBuilder.UseSqlServer(con);
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        public ChallengeNetCoreDbContext()
        {
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
    }
}
