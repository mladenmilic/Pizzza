using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.Models
{
    public class PizzaComponents
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int componentId { get; set; }
        [Key]
        public int pizzaId { get; set; }
        public virtual Pizza pizza { get; set; }
        public string componentsName { get; set; }
        public string quantity { get; set; }
    }
}
