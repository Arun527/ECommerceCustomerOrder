using ECommerceApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ECommerceCustomerOrder.Model
{
    public class ECommmerceDbContext:DbContext
    {
        public ECommmerceDbContext(DbContextOptions<ECommmerceDbContext> options) : base(options) { }

     
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Orders> orders { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        public DbSet<Roll> Roll { get; set; }
    }
}
