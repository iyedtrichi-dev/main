using Microsoft.EntityFrameworkCore;

namespace ProjectX
{
    public class AppDbContext : DbContext
    {
        public DbSet<Camion> Camions { get; set; }
        public DbSet<Tournee> Tournees { get; set; }
        public DbSet<PointCollecte> PointsCollecte { get; set; }
        public DbSet<CentreDeTri> CentresDeTri { get; set; }
        public DbSet<LstRecyclage> LstRecyclages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=projectx.db");
        }
    }
}
