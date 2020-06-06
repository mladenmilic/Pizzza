using Microsoft.EntityFrameworkCore;
using Pizzza.Models;
using Pizzza.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.DataManager
{
    public class PizzaComponentsManager : IPizzaComponentDataRepository
    {
        PizzzaDbContext pizzaContext;
        public PizzaComponentsManager(PizzzaDbContext pc)
        {
            pizzaContext = pc;
        }

        public Task<List<PizzaComponents>> Get(long id)
        {
            var pizzaComponents = (pizzaContext.PizzaComponents
                .Include(p => p.pizza)).Where(pc => pc.pizzaId == (int)id).ToListAsync();
            return pizzaComponents;
        }
    }
}
