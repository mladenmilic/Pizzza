using Microsoft.EntityFrameworkCore;
using Pizzza.Models;
using Pizzza.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.DataManager
{
    public class PizzaManager : IPizzaDataRepository
    {
        PizzzaDbContext pizzaContext;
        public PizzaManager(PizzzaDbContext pc)
        {
            pizzaContext = pc;
        }

        public async Task<long> Add(Pizza pizza)
        {
            pizzaContext.Pizzas.Add(pizza);
            long pizzaID = pizzaContext.SaveChanges();
            int id = pizza.pizzaId;
            return pizzaID;
        }

        public async Task<long> Delete(long id)
        {
            int pizzaId = 0;
            var pizza = pizzaContext.Pizzas.FirstOrDefault(p => p.pizzaId == id);
            if (pizza != null)
            {
                pizzaContext.Pizzas.Remove(pizza);
                pizzaId = pizzaContext.SaveChanges();
            }
            return pizzaId;
        }

        public async Task<Pizza> Get(long id)
        {
            var pizza = pizzaContext.Pizzas.FirstOrDefault(p => p.pizzaId == id);
            pizza.pizzaComponents = await (pizzaContext.PizzaComponents).Where(p => p.pizzaId == (int)id).ToListAsync();
            return pizza;
        }

        public async Task<List<Pizza>> GetAll()
        {
            var pizzas = pizzaContext.Pizzas.Include(p => p.pizzaComponents).ToList();
            return GetListPizza(pizzas);
        }

        private List<Pizza> GetListPizza(List<Pizza> listPiza)
        {
            return listPiza;
        }
        
        public async Task<List<Pizza>> GetPizzaByPrice(double? priceFrom, double? priceTo)
        {
            List<Pizza> pizzas = new List<Pizza>();
            if (priceFrom != null && priceTo != null)
            {
                pizzas = pizzaContext.Pizzas.Where(p => p.price >= priceFrom && p.price <= priceTo).ToList();
                return pizzas;
            }
            if (priceFrom == null && priceTo != null)
            {
                pizzas = pizzaContext.Pizzas.Where(p => p.price <= priceTo).ToList();
                return pizzas;
            }
            if (priceFrom != null && priceTo == null)
            {
                pizzas = pizzaContext.Pizzas.Where(p => p.price >= priceFrom).ToList();
                return pizzas;
            }
            pizzas = pizzaContext.Pizzas.ToList();
            return pizzas;
        }

        public async Task<long> Update(long id, Pizza p)
        {
            long pizzaId = 0;
            var pizza = await Get(id);
            if (pizza != null)
            {
                pizza.pizzaName = p.pizzaName;
                pizza.pizzaComponents = p.pizzaComponents;
                pizza.price = p.price;
                pizzaId = pizzaContext.SaveChanges();
            }
            return pizzaId;
        }
    }
}
