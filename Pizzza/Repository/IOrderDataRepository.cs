using Pizzza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.Repository
{
    public interface IOrderDataRepository
    {
        Task<List<Order>> GetAll();
        Task<Order> Get(long id);
        Task<long> Add(Order b);
        Task<long> Update(long id, Order b);
        Task<long> Delete(long id);
        Task<List<Order>> GetOrdersByDates(DateTime? dateFrom, DateTime? dateTo);
    }
}
