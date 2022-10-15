using Domain.Model.Orders.Specification;
using Framework.Domain;
using System.Net;

namespace Domain.Model.Orders
{
    public class Order : AggregateRoot<long>
    {
        public Order
            (string number, DateTime createdDateTime,
            List<OrderItem> orderItems, Address address,
            string? description)
        {
            Number = number;
            CreatedDateTime = createdDateTime;
            _orderItems = orderItems;
            Address = address;
            Description = description;
        }

        private Order() { }

        public Address Address { get; private set; }
        public string? Description { get; private set; }
        public string Number { get; private set; }
        public DateTime CreatedDateTime { get; private set; }

        private readonly List<OrderItem> _orderItems = new();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public void Archive()
        {
            var date = DateTime.Now.AddYears(-1);
            var specification = new SmallerThanDateSpecification(date);

            if (specification.IsSatisfiedBy(this))
            {
                // archive order
            }
        }
    }
}
