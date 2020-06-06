using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pizzza.Controllers
{
    [Route("start")]
    [ApiController]
    public class StartController : Controller
    {
        [Route("api")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "SERVIS JE POKRENUT" };
        }
    }
}
