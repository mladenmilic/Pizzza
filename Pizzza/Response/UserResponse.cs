using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.Models.Response
{
    public class UserResponse
    {
        public int userId { get; set; }
        public string fullName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string Token { get; set; }
    }
}
