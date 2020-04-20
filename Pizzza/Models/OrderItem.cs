using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int itemId { get; set; }
        [Key]
        public int orderId { get; set; }
        public virtual  Order order  { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double amount { get; set; }
        public int pizzaId { get; set; }
        public  virtual Pizza pizza { get; set; }
    }
}
