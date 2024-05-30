using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Klinika.Models;

namespace Klinika.Data.EntityTypeConfiguration
{
    public class ClientTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                .IsRequired();

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.Surname)
                .IsRequired();

            builder.HasMany(e => e.Cats)
                .WithMany(e => e.Owners);
        }
    }
}
