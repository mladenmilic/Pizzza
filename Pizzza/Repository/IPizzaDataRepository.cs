using Pizzza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.Repository
{
    public interface IPizzaDataRepository
    {
        Task<List<Pizza>> GetAll();
        Task<Pizza> Get(long id);
        Task<long> Add(Pizza b);
        Task<long> Update(long id, Pizza b);
        Task<long> Delete(long id);
        Task<List<Pizza>> GetPizzaByPrice(double? priceFrom, double? priceTo);
    }
}
