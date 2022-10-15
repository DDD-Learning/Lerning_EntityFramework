using Domain.Model.Orders;
using Microsoft.EntityFrameworkCore;
using Persistence.EF.Mappings;

namespace Persistence.EF
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options): base(options)
        { 
        }

        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Server=localhost;Database=OrdersApplication;User Id=sa;Password=P@ssw0rd;");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderMapping).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
