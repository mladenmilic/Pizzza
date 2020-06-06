using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzza.Models
{
    public class Pizza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int pizzaId { get; set; }
        public string pizzaName { get; set; }
        public double price { get; set; }
        public virtual ICollection<PizzaComponents> pizzaComponents { get; set; }

    }
}
