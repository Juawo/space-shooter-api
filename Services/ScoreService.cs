using SpaceShooterApi.Database;
using SpaceShooterApi.Interfaces.Repositories;
using SpaceShooterApi.Models;

namespace SpaceShooterApi.Services;

public class ScoreService(IScoreRepository scoreRepository, AppDbContext appDbContext)
{
    public async Task<IEnumerable<Score>> GetAllScore()
        => await scoreRepository.GetAllScore();

    public async Task<Score?> GetScoreById(Guid scoreId)
        => await scoreRepository.GetScoreById(scoreId);

    public async Task<bool> CreateScore(Score score)
    {
        await scoreRepository.CreateScore(score);
        await appDbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> UpdateScore(Score score)
    {
        var oldScore = await scoreRepository.GetScoreById(score.Id);
        if (oldScore != null && oldScore.Value > score.Value) return false;
        scoreRepository.UpdateScore(score);
        await appDbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> RemoveScore(Score score)
    {
        scoreRepository.RemoveScore(score);
        await appDbContext.SaveChangesAsync();
        return true;
    }
}