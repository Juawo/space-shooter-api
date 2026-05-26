using Microsoft.EntityFrameworkCore;
using SpaceShooterApi.Database;
using SpaceShooterApi.Interfaces.Repositories;
using SpaceShooterApi.Models;

namespace SpaceShooterApi.Repositories;

public class GameVersionsRepository(AppDbContext dbContext) : IGameVersionsRepository
{
    public async Task CreateGameVersion(GameVersion gameVersion)
    {
        await dbContext.GameVersions.AddAsync(gameVersion);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateGameVersion(GameVersion gameVersion)
    {
        dbContext.GameVersions.Update(gameVersion);
        await dbContext.SaveChangesAsync();
    }

    public async Task RemoveGameVersion(GameVersion gameVersion)
    {
        dbContext.GameVersions.Remove(gameVersion);
        await dbContext.SaveChangesAsync();
    }

    public async Task<GameVersion?> GetGameVersionById(Guid gameVersionId)
    {
        return await dbContext.GameVersions.FindAsync(gameVersionId);
    }
    
    public async Task<GameVersion?> GetLatestVersion()
    {
        return await dbContext.GameVersions.OrderByDescending(version => version.CreatedAt).FirstOrDefaultAsync();
    }
    
    public async Task<GameVersion?> GetGameVersionByCurrentVersion(string currentVersion)
    {
        return await dbContext.GameVersions.FirstOrDefaultAsync(version => version.CurrentVersion == currentVersion);
    }
}