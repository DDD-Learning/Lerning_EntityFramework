using Framework.Core.Specification;

namespace Domain.Model.Orders.Specification
{
    public class SmallerThanDateSpecification : CompositeSpecification<Order>
    {
        private readonly DateTime _date;

        public SmallerThanDateSpecification(DateTime date)
        {
            _date = date;
        }

        public override bool IsSatisfiedBy(Order entity) =>
            entity.CreatedDateTime.Date < _date.Date;
    }
}
