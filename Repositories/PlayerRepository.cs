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

    public async Task<Player?> GetPlayerByNickname(string nickname)
        => await dbContext.Players.FirstOrDefaultAsync(p => p.Nickname == nickname);

    public async Task<bool> NicknameExistsForAnotherPlayer(string nickname, Guid playerId)
    {
        return await dbContext.Players.AnyAsync(p => p.Nickname == nickname && p.Id != playerId);
    }

    public async Task CreatePlayer(Player player)
    {
        await dbContext.Players.AddAsync(player);
        await dbContext.SaveChangesAsync();
    }
    public async Task UpdatePlayer(Player player)
    {
        dbContext.Update(player);
        await dbContext.SaveChangesAsync();
    }

    public async Task RemovePlayer(Player player)
    { 
        dbContext.Players.Remove(player);
        await dbContext.SaveChangesAsync();
    }
}