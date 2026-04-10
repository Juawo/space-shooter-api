using SpaceShooterApi.Models;

namespace SpaceShooterApi.Interfaces.Repositories;

public interface IHighScoreRepository
{
    Task<IEnumerable<HighScore>> GetAllScore();
    Task<HighScore?> GetScoreById(Guid scoreId);
    Task<HighScore?> GetScoreByPlayerId(Guid playerId);
    Task<List<HighScore>> GetScoresWithPlayers();
    Task CreateScore(HighScore score);
    Task UpdateScore(HighScore score);
    Task RemoveScore(HighScore score);
}