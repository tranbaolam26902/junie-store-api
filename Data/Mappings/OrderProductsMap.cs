using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings {
    public class OrderProductsMap : IEntityTypeConfiguration<OrderProducts> {
        public void Configure(EntityTypeBuilder<OrderProducts> builder) {
            builder.ToTable("OrderProducts");

            builder.Property(o => o.Quantity)
                .IsRequired()
                .HasDefaultValue(1);

            builder.HasKey(o => new {
                o.OrderId,
                o.ProductId
            });
        }
    }
}
