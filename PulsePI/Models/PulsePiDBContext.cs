using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PulsePI.Models
{
    public class PulsePiDBContext : DbContext
    {
        public DbSet<Account> accounts { get; set; }
        public DbSet<HeartRateRecord> heartRateRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:pulsepidev.database.windows.net,1433;Initial Catalog=PulsePI;Persist Security Info=False;User ID=pulseadmin;Password=Clutching$kitten;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
