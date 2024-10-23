using ECommerceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products {  get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
