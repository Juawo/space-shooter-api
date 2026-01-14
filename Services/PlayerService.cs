using SpaceShooterApi.Database;
using SpaceShooterApi.Interfaces.Repositories;
using SpaceShooterApi.Models;
using SpaceShooterApi.Repositories;

namespace SpaceShooterApi.Services;

public class PlayerService(IPlayerRepository repository, AppDbContext dbContext)
{
    private readonly IPlayerRepository _repository = repository;
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<bool> CreatePlayer(Player player)
    {
        await _repository.CreatePlayer(player);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Player?> GetPlayerById(Guid playerId)
    {
        return await _repository.GetPlayerById(playerId) ?? null;
    }

    public async Task<IEnumerable<Player>> GetAllPlayers()
    {
        return await _repository.GetAllPlayers();
    }

    public async Task<bool> UpdatePlayer(Player player)
    {
         _repository.UpdatePlayer(player);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePlayer(Player player)
    {
        _repository.RemovePlayer(player);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}