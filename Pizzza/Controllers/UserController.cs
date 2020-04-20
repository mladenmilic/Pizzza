using Microsoft.AspNetCore.Mvc;
using Pizzza.Models;
using Pizzza.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : Controller
    {
        private IDataRepository _iRepo;
        public UserController(IDataRepository repo)
        {
            _iRepo = repo;
        }

        [HttpGet]
        [Route("list-user")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var response = await _iRepo.GetAllAsync();
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    message = "Greska"
                });
            }
        }
        [HttpPost]
        [Route("list-user/user")]
        public async Task<IActionResult> GetUser([FromBody] User user)
        {
            try
            {
                var response = await _iRepo.Get(user.username,user.password);
                 return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    message = "Pogrešena username ili password"
                });
            }
        }
    }
}
