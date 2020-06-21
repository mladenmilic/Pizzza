using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.Models
{
    public class Place
    {
        [Key]
        public int zipCode { get; set; }
        public string township { get; set; }
        public virtual ICollection<Order> orders { get; set; }

    }
}
