using Microsoft.EntityFrameworkCore;
using SpaceShooterApi.Database;
using SpaceShooterApi.Interfaces.Repositories;
using SpaceShooterApi.Middleware;
using SpaceShooterApi.Repositories;
using SpaceShooterApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});

// Repositories
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IScoreRepository, ScoreRepository>();
// Services
builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<ScoreService>();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>(); 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.SwaggerEndpoint("/swagger/v1/swagger.json", "SpaceShooterApi v1");
    });
}

app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();