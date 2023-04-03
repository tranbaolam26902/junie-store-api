using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings {
    public class DiscountMap : IEntityTypeConfiguration<Discount> {
        public void Configure(EntityTypeBuilder<Discount> builder) {
            builder.ToTable("Discounts");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Code)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(d => d.Value)
                .IsRequired();

            builder.Property(d => d.MinPrice)
                .HasDefaultValue(0);

            builder.Property(d => d.ExpiryDate)
                .HasColumnType("datetime");

            builder.Property(d => d.IsActive)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}
