using Klinika.Data.EntityTypeConfiguration;
using Klinika.Models;
using Microsoft.EntityFrameworkCore;

namespace Klinika.Data
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build().GetConnectionString("DefaultConnection") ??
                throw new NullReferenceException("Database connection string could not be loaded!");
            optionsBuilder.UseSqlServer(connection);
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
