﻿using DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace DAL
{
    public class ResturantsContext : DbContext
    {
        public ResturantsContext()
        {

        }
        public ResturantsContext(DbContextOptions<ResturantsContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Oreders { get; set; }
       public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Resturant>().ToTable("Resturant");
            modelBuilder.Entity<Menu>().ToTable("Menu");

        }

    }

}