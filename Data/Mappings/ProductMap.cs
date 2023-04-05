using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings {
    public class ProductMap : IEntityTypeConfiguration<Product> {
        public void Configure(EntityTypeBuilder<Product> builder) {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(p => p.Slug)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.Discount)
                .HasDefaultValue(0);

            builder.Property(p => p.Quantity)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.Type)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(p => p.TotalSold)
                .HasDefaultValue(0);

            builder.Property(p => p.Ratings)
                .HasDefaultValue(0);

            builder.Property(p => p.Description)
                .IsRequired();

            builder.Property(p => p.UserManual)
                .IsRequired();

            builder.Property(p => p.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasOne(p => p.Collection)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CollectionId)
                .HasConstraintName("FK_Products_Collections")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.OrderProducts)
                .WithOne(o => o.Product)
                .HasForeignKey(o => o.ProductId)
                .HasConstraintName("FK_Products_Orders")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
