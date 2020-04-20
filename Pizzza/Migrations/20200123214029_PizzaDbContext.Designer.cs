﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pizzza.Models;

namespace Pizzza.Migrations
{
    [DbContext(typeof(PizzzaDbContext))]
    [Migration("20200123214029_PizzaDbContext")]
    partial class PizzaDbContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pizzza.Models.Order", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("date");

                    b.Property<string>("phoneNumber");

                    b.Property<int>("placezipCode");

                    b.Property<string>("street");

                    b.Property<double>("totalAmount");

                    b.Property<int>("userId");

                    b.HasKey("orderId");

                    b.HasIndex("placezipCode");

                    b.HasIndex("userId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Pizzza.Models.OrderItem", b =>
                {
                    b.Property<int>("itemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("orderId");

                    b.Property<double>("amount");

                    b.Property<int>("pizzaId");

                    b.Property<double>("price");

                    b.Property<int>("quantity");

                    b.HasKey("itemId", "orderId");

                    b.HasIndex("orderId");

                    b.HasIndex("pizzaId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Pizzza.Models.Pizza", b =>
                {
                    b.Property<int>("pizzaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description");

                    b.Property<string>("pizzaName");

                    b.Property<double>("price");

                    b.HasKey("pizzaId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("Pizzza.Models.Place", b =>
                {
                    b.Property<int>("zipCode")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("township");

                    b.HasKey("zipCode");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Pizzza.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fullName");

                    b.Property<string>("password");

                    b.Property<string>("role");

                    b.Property<string>("username");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Pizzza.Models.Order", b =>
                {
                    b.HasOne("Pizzza.Models.Place", "place")
                        .WithMany()
                        .HasForeignKey("placezipCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Pizzza.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Pizzza.Models.OrderItem", b =>
                {
                    b.HasOne("Pizzza.Models.Order", "order")
                        .WithMany("orderItems")
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Pizzza.Models.Pizza", "pizza")
                        .WithMany()
                        .HasForeignKey("pizzaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}