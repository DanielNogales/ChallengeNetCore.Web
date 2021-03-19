using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeNetCore.Web.Models
{
    public class PriceList
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public int Price { get; set; }

        public DateTime Date { get; set; }
    }
}
