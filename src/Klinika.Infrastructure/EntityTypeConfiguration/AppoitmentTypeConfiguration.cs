using Klinika.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Klinika.Infrastructure.EntityTypeConfiguration
{
    public class AppoitmentTypeConfiguration : IEntityTypeConfiguration<Appoitment>
    {
        public void Configure(EntityTypeBuilder<Appoitment> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.Property(x => x.GUID)
            //    .IsRequired();

            builder.Property(e => e.Date)
                .IsRequired();

            builder.HasOne(e => e.Cat)
                .WithMany()
                .HasForeignKey(e => e.CatId)
                .IsRequired();

            builder.HasOne(e => e.Client)
                .WithMany()
                .HasForeignKey(e => e.ClientId)
                .IsRequired();
        }
    }
}