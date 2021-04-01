using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChallengeNetCore.Web.Models
{
    public class PriceList
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Price { get; set; }

        public DateTime Date { get; set; }
    }
}
