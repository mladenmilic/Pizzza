using Microsoft.AspNetCore.Mvc;
using Pizzza.Models;
using Pizzza.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : Controller
    {
        private IOrderDataRepository _iRepo;
        public OrderController(IOrderDataRepository repo)
        {
            _iRepo = repo;
        }

        [HttpGet]
        [Route("list-order")]
        public async Task<IActionResult> GetListOrder()
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
                    message = "Lista porudžbina nije učitana !"
                });
            }
        }

        [HttpGet]
        [Route("list-order/{orderId}")]
        public async Task<IActionResult> getOrder([FromRoute]  long orderId)
        {
            try
            {
                var order = await _iRepo.Get(orderId);
                return Ok(order);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Nije pronađena nijedna porudžbina po zadatoj šifri !" });
            }
        }
        [HttpPost]
        [Route("add-order")]
        public async Task<IActionResult> addOrder([FromBody] Order order)
        {
            try
            {
                long orderId = await _iRepo.Add(order);
                return Ok(orderId);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.ToString() });
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> updateOrder([FromBody] Order order)
        {
            try
            {
                long id = await _iRepo.Update(order.orderId, order);
                return Ok(id);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Greska !" });
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> deleteOrder([FromRoute] long id)
        {
            try
            {
                long idPizza = await _iRepo.Delete((int)id);
                return Ok(idPizza);
            }
            catch (Exception)
            {
                return BadRequest("Greska!");
            }
        }
        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> fillterByDate([FromQuery] DateTime ? dateFrom, [FromQuery] DateTime ? dateTo)
        {
            try
            {
                if (dateFrom > dateTo) {
                    throw new Exception("Datum od je veci od datuma do !");
                }
                var order = await _iRepo.GetOrdersByDates(dateFrom,dateTo);
                return Ok(order);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Nije pronađena nijedna porudžbina po zadatim datumima !" });
            }
        }
    }
}
