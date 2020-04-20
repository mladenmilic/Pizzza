using Microsoft.EntityFrameworkCore;
using Pizzza.Models;
using Pizzza.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.DataManager
{
    public class OrderItemManager : IDataRepository<OrderItem, long>
    {
        PizzzaDbContext pizzaContext;
        public OrderItemManager(PizzzaDbContext pc)
        {
            pizzaContext = pc;
        }
        public Task<long> Add(OrderItem b)
        {
            throw new NotImplementedException();
        }

        public Task<long> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderItem>> Get(long id)
        {
            var orderItem = (pizzaContext.OrderItems
                .Include(p => p.pizza)).Where(oi => oi.orderId == (int)id).ToListAsync();
            return orderItem;
        }

        public Task<List<OrderItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderItem>> GetOrdersByDates(DateTime ? dateFrom, DateTime ? dateTo)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderItem>> GetPizzaByPrice(double? priceFrom, double? priceTo)
        {
            throw new NotImplementedException();
        }

        public Task<long> Update(long id, OrderItem b)
        {
            throw new NotImplementedException();
        }

        Task<OrderItem> IDataRepository<OrderItem, long>.Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}
