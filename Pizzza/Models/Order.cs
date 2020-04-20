using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; }
        public DateTime date { get; set; }
        public double totalAmount { get; set; }
        public string street { get; set; }
        public string phoneNumber { get; set; }
        public int placezipCode { get; set; }
        public int userId { get; set; }
        public virtual  Place place { get; set; }
        public virtual User user { get; set; }
        public virtual ICollection<OrderItem> orderItems { get; set; }
    }
}
