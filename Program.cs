using Microsoft.EntityFrameworkCore;
using SpaceShooterApi.Database;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
