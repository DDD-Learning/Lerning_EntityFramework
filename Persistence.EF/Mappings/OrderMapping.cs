using Domain.Model.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EF.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders").HasKey(c => c.Id);

            builder.Property(c => c.Number)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(c => c.Description)
                .HasMaxLength(100);

            builder.OwnsMany(a => a.OrderItems, map =>
            {
                map.ToTable("OrderItems").HasKey("Id");
                map.Property<long>("Id").ValueGeneratedOnAdd();
                map.WithOwner().HasForeignKey("OrderId");

                map.UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.OwnsOne(c => c.Address, orderAddress =>
            {
                orderAddress.Property(a => a.PostalCode)
                    .HasColumnName("PostalCode")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsRequired(true);

                orderAddress.Property(a => a.Street)
                    .HasColumnName("Street")
                    .HasMaxLength(20)
                    .IsRequired(true);

                orderAddress.Property(a => a.City)
                    .HasColumnName("City")
                    .HasMaxLength(20)
                    .IsRequired(true);
            });

        }
    }
}
