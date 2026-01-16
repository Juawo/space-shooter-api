using Microsoft.EntityFrameworkCore;
using SpaceShooterApi.Database;
using SpaceShooterApi.Interfaces.Repositories;
using SpaceShooterApi.Repositories;
using SpaceShooterApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});

// Repositories
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
// Services
builder.Services.AddScoped<PlayerService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();
