using Pizzza.Models;
using Pizzza.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.DataManager
{
    public class PlaceManager : IPlaceDataRepository
    {
        PizzzaDbContext pizzaContext;
        public PlaceManager(PizzzaDbContext pc)
        {
            pizzaContext = pc;
        }

        public async Task<List<Place>> GetAll()
        {
            return pizzaContext.Places.ToList();
        }

        public async Task<Place> Get(int id)
        {
            var place = pizzaContext.Places.FirstOrDefault(p => p.zipCode == id);
            return place;
        }
    }
}
