namespace Domain.Model.Orders
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order newOrder);
        Task<Order> GetByIdAsync(long id);
    }
}
