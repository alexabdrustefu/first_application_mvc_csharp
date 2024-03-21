using Microsoft.EntityFrameworkCore;
using first_mvc_pattern_c_.Models;

namespace first_mvc_pattern_c_.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Definizione delle entità del database come DbSet
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Film> Films { get; set; }

        // Override del metodo OnModelCreating per configurare il modello
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura il modello, se necessario
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Film>()
                .HasOne(f => f.Cinema)
                .WithMany(c => c.Films)
                .HasForeignKey(f => f.CinemaId);
        }
    }
}
