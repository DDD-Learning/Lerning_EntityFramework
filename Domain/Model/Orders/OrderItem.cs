using Framework.Domain;

namespace Domain.Model.Orders
{
    public class OrderItem : ValueObject<OrderItem>
    {
        public OrderItem(long productId, decimal price, int count)
        {
            ProductId = productId;
            Price = price;
            Count = count;
        }

        public long ProductId { get; private set; }
        public decimal Price { get; private set; }
        public int Count { get; private set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return ProductId;
            yield return Price;
            yield return Count;
        }
    }
}
