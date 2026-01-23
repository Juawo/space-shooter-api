using SpaceShooterApi.Models;

namespace SpaceShooterApi.Interfaces.Repositories;

public interface IHighScoreRepository
{
    Task<IEnumerable<HighScore>> GetAllScore();
    Task<HighScore?> GetScoreById(Guid scoreId);
    Task<HighScore?> GetScoreByPlayerId(Guid playerId);
    Task CreateScore(HighScore score);
    void UpdateScore(HighScore score);
    void RemoveScore(HighScore score);
}