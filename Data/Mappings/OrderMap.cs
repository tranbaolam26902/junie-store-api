using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings {
    public class OrderMap : IEntityTypeConfiguration<Order> {
        public void Configure(EntityTypeBuilder<Order> builder) {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.OrderDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(o => o.PhoneNumber)
                .IsRequired()
                .HasMaxLength(16);

            builder.Property(o => o.Email)
                .HasMaxLength(64);

            builder.Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(o => o.Address)
                .IsRequired()
                .HasMaxLength(512);

            builder.Property(o => o.AddressDescription)
                .HasMaxLength(512);

            builder.Property(o => o.Notes)
                .HasMaxLength(1024);

            builder.Property(o => o.IsConfirmed)
                .HasDefaultValue(false);

            builder.HasMany(o => o.OrderProducts)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId)
                .HasConstraintName("FK_Orders_OrderProducts")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
