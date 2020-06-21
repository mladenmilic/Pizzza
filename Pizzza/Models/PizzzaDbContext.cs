using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.Models
{
    public class PizzzaDbContext: DbContext
    {
        public PizzzaDbContext(DbContextOptions opts) : base(opts)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaComponents> PizzaComponents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Place> Places { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>(oi => oi.order)
                .WithMany(o =>o.orderItems)
                .HasForeignKey(c => c.orderId );

            modelBuilder.Entity<OrderItem>()
                .HasKey(c => new { c.itemId, c.orderId });

            modelBuilder.Entity<PizzaComponents>()
                .HasOne<Pizza>(pc => pc.pizza).
                WithMany(p => p.pizzaComponents).
                HasForeignKey(pizzaC => pizzaC.pizzaId);

            modelBuilder.Entity<PizzaComponents>()
               .HasKey(c => new { c.componentId, c.pizzaId });

            modelBuilder.Entity<Order>()
                .HasOne<User>(o => o.user)
                .WithMany(u => u.orders)
                .HasForeignKey(or => or.userId);

            modelBuilder.Entity<Order>()
                .HasOne<Place>(o => o.place)
                .WithMany(p => p.orders)
                .HasForeignKey(or => or.placezipCode);

            base.OnModelCreating(modelBuilder);
        }

    }
}
