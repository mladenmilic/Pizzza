using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.Repository
{
    public interface IDataRepository<TEntity, U> where TEntity : class
    {

        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(U id);
        Task<long> Add(TEntity b);
        Task<long> Update(U id, TEntity b);
        Task<long> Delete(U id);
        Task<List<TEntity>> GetOrdersByDates(DateTime ? dateFrom, DateTime ? dateTo);
        Task<List<TEntity>> GetPizzaByPrice(double ? priceFrom, double? priceTo);
    }
}
