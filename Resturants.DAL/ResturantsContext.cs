
using Microsoft.EntityFrameworkCore;
using Resturants.DAL.Models;


namespace Resturants.DAL
{
    public class ResturantsContext : DbContext
    {
        //public ResturantsContext()
        //{

        //}
        public ResturantsContext(DbContextOptions<ResturantsContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Oreders { get; set; }
       public DbSet<Resturants.DAL.Models.Resturant> Resturants { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public DbSet<ItemOrder> ItemOrders { get; set; }

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }

}