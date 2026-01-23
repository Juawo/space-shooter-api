using Microsoft.EntityFrameworkCore;
using SpaceShooterApi.Models;

namespace SpaceShooterApi.Database;

public class AppDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<HighScore> HighScores { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Player>()
            .HasOne(p => p.HighScore)
            .WithOne(h => h.Player)
            .HasForeignKey<HighScore>(h => h.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}