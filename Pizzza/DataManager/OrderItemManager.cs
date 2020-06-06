using Microsoft.EntityFrameworkCore;
using Pizzza.Models;
using Pizzza.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.DataManager
{
    public class OrderItemManager : IOrderItemDataRepository
    {
        PizzzaDbContext pizzaContext;
        public OrderItemManager(PizzzaDbContext pc)
        {
            pizzaContext = pc;
        }
      
        public Task<List<OrderItem>> Get(long id)
        {
            var orderItem = (pizzaContext.OrderItems
                .Include(p => p.pizza)).Where(oi => oi.orderId == (int)id).ToListAsync();
            return orderItem;
        }
    }
}
