using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }
        public string fullName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public virtual ICollection<Order> orders { get; set; }

    }
}
