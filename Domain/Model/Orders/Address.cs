using Framework.Domain;

namespace Domain.Model.Orders
{
    public class Address : ValueObject<Address>
    {
        public Address(string poctalCode, string city, string street)
        {
            PostalCode = poctalCode;
            City = city;
            Street = street;
        }

        private Address() { }

        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return PostalCode;
            yield return City;
            yield return Street;
        }
    }
}
