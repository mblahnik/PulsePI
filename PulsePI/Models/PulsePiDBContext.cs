using Microsoft.EntityFrameworkCore;

namespace PulsePI.Models
{
    public class PulsePiDBContext : DbContext
    {
        public DbSet<Account> accounts { get; set; }
        public DbSet<HeartRateRecord> heartRateRecords { get; set; }
        public DbSet<Biometric> biometrics { get; set; }

        public PulsePiDBContext(DbContextOptions<PulsePiDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
