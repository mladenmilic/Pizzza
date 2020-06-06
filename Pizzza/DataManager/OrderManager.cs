using Microsoft.EntityFrameworkCore;
using Pizzza.Models;
using Pizzza.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.DataManager
{
    public class OrderManger : IOrderDataRepository
    {
        PizzzaDbContext pizzaContext;
        public OrderManger(PizzzaDbContext pc)
        {
            pizzaContext = pc;
        }

        public async Task<long> Add(Order order)
        {
            pizzaContext.Orders.Add(order);
            pizzaContext.SaveChanges();
            long id = order.orderId;
            return id;
        }

        public async Task<long> Delete(long id)
        {
            int orderId = 0;
            var order = pizzaContext.Orders.FirstOrDefault(o => o.orderId == (int)id);
            if (order != null)
            {
                pizzaContext.Orders.Remove(order);
                orderId = pizzaContext.SaveChanges();
            }

            return orderId;
        }

        public async Task<Order> Get(long id)
        {
            Order order = pizzaContext.Orders.FirstOrDefault(o => o.orderId == id);
            order.orderItems = await (pizzaContext.OrderItems
                .Include(p => p.pizza)).Where(oi => oi.orderId == (int)id).ToListAsync();
            order.user = pizzaContext.Users.FirstOrDefault(u => u.userId == order.userId);
            order.place = pizzaContext.Places.FirstOrDefault(p => p.zipCode == order.placezipCode);
            return order;
        }

        public async Task<List<Order>> GetAll()
        {
            List<Order> orders = pizzaContext.Orders
                .Include(oi => oi.orderItems)
                .Include(u => u.user)
                .Include(p => p.place).ToList();
            return getListOrders(orders);
        }

        private List<Order> getListOrders(List<Order> orders)
        {
            foreach (Order o in orders)
            {
                foreach (OrderItem oi in o.orderItems)
                {
                    oi.pizza = pizzaContext.Pizzas.FirstOrDefault(p => p.pizzaId == oi.pizzaId);
                }
            }
            return orders;
        }

        public async Task<long> Update(long id, Order o)
        {
            long orderID = 0;
            var order = await Get((int)id);
            if (order != null)
            {
                order.date = o.date;
                order.orderItems = o.orderItems;
                order.placezipCode = o.placezipCode;
                order.totalAmount = o.totalAmount;
                order.userId = o.userId;
                order.phoneNumber = o.phoneNumber;
                order.street = o.street;
                orderID = pizzaContext.SaveChanges();
            }
            return orderID;
        }

        public async Task<List<Order>> GetOrdersByDates(DateTime ? dateFrom, DateTime ? dateTo)
        {
            List<Order> orders = new List<Order>();
            if (dateTo == null && dateFrom != null)
            {
                orders = pizzaContext.Orders
                            .Include(oi => oi.orderItems)
                            .Include(u => u.user)
                            .Include(p => p.place).Where(o => o.date >= dateFrom).ToList();
                return getListOrders(orders);
            }
            if (dateFrom == null && dateTo != null)
            {
                orders = pizzaContext.Orders
                            .Include(oi => oi.orderItems)
                            .Include(u => u.user)
                            .Include(p => p.place).Where(o => o.date <= dateTo).ToList();
                return getListOrders(orders);
            }
            if (dateFrom == null && dateTo == null)
            {
               return await GetAll();
            }
             orders = pizzaContext.Orders
                            .Include(oi => oi.orderItems)
                            .Include(u => u.user)
                            .Include(p => p.place).Where(o => o.date >= dateFrom && o.date <= dateTo).ToList();
            return getListOrders(orders);
        }
    }
}
