using ChallengeNetCore.Web.Models;
using System;

namespace ChallengeNetCore.Web.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public Category Category { get; set; }
    }
}
