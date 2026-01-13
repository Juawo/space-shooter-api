using Microsoft.EntityFrameworkCore;
using SpaceShooterApi.Database;

namespace SpaceShooterApi.Repositories;
using SpaceShooterApi.Interfaces.Repositories;
using Models;

public class PlayerRepository(AppDbContext dbContext) : IPlayerRepository
{
    public async Task<IEnumerable<Player>> GetAllPlayers()
        => await dbContext.Players.ToListAsync();

    public async Task<Player?> GetPlayerById(Guid playerId)
       => await dbContext.Players.FindAsync(playerId);

    public async Task CreatePlayer(Player player)
        => await dbContext.Players.AddAsync(player);

    public async void UpdatePlayer(Player player)
        => dbContext.Update(player);

    public void RemovePlayer(Player player)
        => dbContext.Players.Remove(player);
}