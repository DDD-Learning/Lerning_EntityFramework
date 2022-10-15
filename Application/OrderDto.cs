namespace Application
{
    public class OrderDto
    {
        public string Number { get; set; }
        public string Description { get; set; }
        public long ProductId { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public IList<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }

    public class OrderItemDto
    {
        public long ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}