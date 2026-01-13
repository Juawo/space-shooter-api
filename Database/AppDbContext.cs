using Microsoft.EntityFrameworkCore;
using SpaceShooterApi.Models;

namespace SpaceShooterApi.Database;

public class AppDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Score> Scores { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}
}