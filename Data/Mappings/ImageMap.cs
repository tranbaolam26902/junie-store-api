using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings {
    public class ImageMap : IEntityTypeConfiguration<Image> {
        public void Configure(EntityTypeBuilder<Image> builder) {
            builder.ToTable("Images");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Path)
                .IsRequired()
                .HasMaxLength(512);

            builder.HasOne(i => i.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
