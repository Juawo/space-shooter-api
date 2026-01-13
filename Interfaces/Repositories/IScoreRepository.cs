using SpaceShooterApi.Models;

namespace SpaceShooterApi.Interfaces.Repositories;

public interface IScoreRepository
{
    Task<IEnumerable<Score>> GetAllScore();
    Task<Score?> GetScoreById(Guid scoreId);
    Task CreateScore(Score score);
    void UpdateScore(Score score);
    void RemoveScore(Score score);
}