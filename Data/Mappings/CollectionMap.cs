using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings {
    public class CollectionMap : IEntityTypeConfiguration<Collection> {
        public void Configure(EntityTypeBuilder<Collection> builder) {
            builder.ToTable("Collections");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(512);

            builder.Property(c => c.Slug)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(c => c.ImagePath)
                .IsRequired()
                .HasMaxLength(512);
        }
    }
}
