using Domain.Model.Orders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EF
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbSet<Order> _dbSet;
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _dbSet = context.Set<Order>();
            _context = context;
        }

        public async Task<Order> GetByIdAsync(long id) =>
            await _dbSet.FindAsync(id);

        public async Task CreateAsync(Order newOrder)
        {
            await _dbSet.AddAsync(newOrder);
            await _context.SaveChangesAsync();
        }
    }
}
