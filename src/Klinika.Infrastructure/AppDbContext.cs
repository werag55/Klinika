using Klinika.Infrastructure.EntityTypeConfiguration;
using Klinika.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Klinika.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<Appoitment> Appoitments { get; set; }

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new AppoitmentTypeConfiguration().Configure(builder.Entity<Appoitment>());
            new CatTypeConfiguration().Configure(builder.Entity<Cat>());
            new ClientTypeConfiguration().Configure(builder.Entity<Client>());
        }
    }
}
