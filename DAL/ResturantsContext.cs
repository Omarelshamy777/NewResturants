using DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace DAL
{
    public class ResturantsContext : DbContext
    {
        public ResturantsContext(DbContextOptions<ResturantsContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Oreders { get; set; }
       public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Food>().ToTable("Food");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Resturant>().ToTable("Resturant");
            modelBuilder.Entity<Menu>().ToTable("Menu");

        }

    }

}