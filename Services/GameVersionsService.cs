using System.Text.RegularExpressions;
using SpaceShooterApi.Interfaces.Repositories;
using SpaceShooterApi.Models;

namespace SpaceShooterApi.Services;

public partial class GameVersionsService(IGameVersionsRepository gameVersionsRepository)
{
    private readonly IGameVersionsRepository _gameVersionsRepository = gameVersionsRepository;
    private static readonly Regex VersionRegex = MyRegex();
    
    public async Task<Result<GameVersion?>> CreateGameVersion(GameVersion gameVersion)
    {
        var existingGameVersion = await _gameVersionsRepository.GetGameVersionByCurrentVersion(gameVersion.CurrentVersion);
        if (existingGameVersion != null)
        {
            return Result<GameVersion?>.Failure(ErrorType.Conflict);
        }

        if (!IsGameVersionValid(gameVersion.CurrentVersion))
        {
            return Result<GameVersion?>.Failure(ErrorType.ValidationError);
        }
        
        await _gameVersionsRepository.CreateGameVersion(gameVersion);
        return Result<GameVersion?>.Ok(gameVersion);
    }

    public async Task<Result<GameVersion?>> GetGameVersionById(Guid gameVersionId)
    {
        var gameVersion = await _gameVersionsRepository.GetGameVersionById(gameVersionId);
        return gameVersion == null?
            Result<GameVersion?>.Failure(ErrorType.NotFound) :
            Result<GameVersion?>.Ok(gameVersion);
    }

    public async Task<Result<GameVersion?>> GetLatestGameVersion()
    {
        var latestGameVersion = await _gameVersionsRepository.GetLatestVersion();
        return latestGameVersion == null ? Result<GameVersion?>.Failure(ErrorType.NotFound) : Result<GameVersion?>.Ok(latestGameVersion);
    }

    private static bool IsGameVersionValid(string currentVersion)
    {
        return !string.IsNullOrEmpty(currentVersion) && VersionRegex.IsMatch(currentVersion);
    }

    [GeneratedRegex(@"^\d+\.\d+\.\d+$", RegexOptions.Compiled)]
    private static partial Regex MyRegex();
}