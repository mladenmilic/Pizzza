using Pizzza.Models;
using Pizzza.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.DataManager
{
    public class PlaceManager : IDataRepository<Place, long>
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

        public Task<List<Place>> GetOrdersByDates(DateTime ? dateFrom, DateTime ? dateTo)
        {
            throw new NotImplementedException();
        }

        public Task<List<Place>> GetPizzaByPrice(double? priceFrom, double? priceTo)
        {
            throw new NotImplementedException();
        }

        Task<long> IDataRepository<Place, long>.Add(Place b)
        {
            throw new NotImplementedException();
        }

        Task<long> IDataRepository<Place, long>.Delete(long id)
        {
            throw new NotImplementedException();
        }

        async Task<Place> IDataRepository<Place, long>.Get(long id)
        {
            var place = pizzaContext.Places.FirstOrDefault(p => p.zipCode == (int)id);
            return place;
        }

        Task<long> IDataRepository<Place, long>.Update(long id, Place b)
        {
            throw new NotImplementedException();
        }
    }
}
