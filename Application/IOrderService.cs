using Domain.Model.Orders;

namespace Application
{
    public interface IOrderService
    {
        Task<Order> GetOrderAsync(long id);
        Task ArchiveAsync(long id);
        Task<long> PlaceOrderAsync(OrderDto viewModel);
    }
}