using Klinika.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Klinika.Data.EntityTypeConfiguration
{
    public class CatTypeConfiguration : IEntityTypeConfiguration<Cat>
    {
        public void Configure(EntityTypeBuilder<Cat> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.Age)
                .IsRequired();

            builder.Property(e => e.Color)
                .IsRequired();

            builder.HasMany(e => e.Owners)
                .WithMany(e => e.Cats);

        }
    }
}
