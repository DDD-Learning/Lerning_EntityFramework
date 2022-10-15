using Domain.Model.Orders;

namespace Application
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task ArchiveAsync(long id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            order.Archive();
        }

        public Task<Order> GetOrderAsync(long id) =>
            _orderRepository.GetByIdAsync(id);

        public async Task<long> PlaceOrderAsync(OrderDto viewModel)
        {
            var orderItems = new List<OrderItem>();

            foreach (var item in orderItems)
            {
                orderItems.Add
                    (new OrderItem(item.ProductId, item.Price, item.Count));
            }

            var address = new Address
                (viewModel.PostalCode, viewModel.City, viewModel.Street);

            var newOrder =
                new Order(viewModel.Number, DateTime.Now, orderItems, address, viewModel.Description);

            await _orderRepository.CreateAsync(newOrder);

            return newOrder.Id;
        }
    }
}