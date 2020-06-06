using Microsoft.AspNetCore.Mvc;
using Pizzza.DataManager;
using Pizzza.Models;
using Pizzza.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.Controllers
{
    [Route("place")]
    [ApiController]
    public class PlaceController : Controller
    {
        private IPlaceDataRepository _iRepo;
        public PlaceController (IPlaceDataRepository repo)
        {
            _iRepo = repo;
        }

        [HttpGet]
        [Route("list-places")]
        public async Task<IActionResult> GetPlaces()
        {
            try
            {
                var response = await _iRepo.GetAll();
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    message = "Greska na serverskoj strani"
                });
            }
        }
        [HttpGet]
        [Route("list-places/{placeId}")]
        public async Task<IActionResult> GetPlace([FromRoute] long placeId)
        {
            try
            {
                var response = await _iRepo.Get((int)placeId);
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
    }
}
