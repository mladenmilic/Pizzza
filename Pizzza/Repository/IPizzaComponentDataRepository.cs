using Pizzza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.Repository
{
    public interface IPizzaComponentDataRepository
    {
        Task<List<PizzaComponents>> Get(long id);

    }
}
