using Microsoft.EntityFrameworkCore;
using OrderCreationDemo.Models;

namespace OrderCreationDemo.Repository
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(o =>
            {
                o.HasKey(order => order.Id);
                o.Property<Guid>(order => order.OrderId).IsRequired();
                o.Property<string>(order => order.CustomerName).IsRequired().HasMaxLength(100);
                o.Property<DateTime>(order => order.CreatedAt).IsRequired();
                o.HasMany(order => order.Items).WithOne().OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}