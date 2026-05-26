using SpaceShooterApi.Models;

namespace SpaceShooterApi.Interfaces.Repositories;

public interface IGameVersionsRepository
{
    Task CreateGameVersion(GameVersion gameVersion);
    Task RemoveGameVersion(GameVersion gameVersion);
    Task<GameVersion?> GetGameVersionById(Guid gameVersionId);
    Task<GameVersion?> GetLatestVersion();
    Task<GameVersion?> GetGameVersionByCurrentVersion(string currentVersion);
    
}