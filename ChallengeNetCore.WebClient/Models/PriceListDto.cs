using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeNetCore.Web.Client.Models
{
    public class PriceListDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string CategoryName { get; set; }

        public int Price { get; set; }

        public DateTime Date { get; set; }
    }
}
