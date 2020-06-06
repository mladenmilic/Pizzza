 using Microsoft.AspNetCore.Mvc;
using Pizzza.Models;
using Pizzza.Repository;
using System;
using System.Threading.Tasks;

namespace Pizzza.Controllers
{
    [Route("pizza")]
    [ApiController]
    public class PizzaController : Controller
    {
        private IPizzaDataRepository _iRepo;
        public PizzaController(IPizzaDataRepository repo)
        {
            _iRepo = repo;
        }

        [HttpGet]
        [Route("list-pizza")]
        public async Task<IActionResult> GetListPizza()
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
                    message = "Greska!"
                });
            }
        }

        [HttpGet]
        [Route("list-pizza/{pizzaId}")]
        public async Task<IActionResult> getPizza([FromRoute]  long pizzaId)
        {
            try
            {
                var pizza = await _iRepo.Get(pizzaId);
                return Ok(pizza);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Greska " });
            }
        }
        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> getPizzaFiltredByPrice([FromQuery]  double? priceFrom,[FromQuery] double ? priceTo )
        {
            try
            {
                var pizza = await _iRepo.GetPizzaByPrice(priceFrom,priceTo);
                return Ok(pizza);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Greska " });
            }
        }
        [HttpPost]
        [Route("add-pizza")]
        public async Task<IActionResult> addPizza([FromBody] Pizza pizza)
        {
            try
            {
                long pizzaId = await _iRepo.Add(pizza);
                return Ok(pizzaId);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Greska " });
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> updatePizza([FromBody] Pizza pizza)
        {
            try
            {
                long pizzaId = await _iRepo.Update(pizza.pizzaId, pizza);
                return Ok(pizzaId);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Greska !" });
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> deletePizza([FromRoute] long id)
        {
            try
            {
                long idPizza = await _iRepo.Delete(id);
                return Ok(idPizza);
            }
            catch (Exception)
            {
                return BadRequest("Greska!");
            }
        }
    }
}
