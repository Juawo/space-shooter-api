using SpaceShooterApi.Database;
using SpaceShooterApi.Interfaces.Repositories;
using SpaceShooterApi.Models;

namespace SpaceShooterApi.Services;

public class HighScoreService(IHighScoreRepository highScoreRepository, AppDbContext appDbContext)
{
    public async Task<IEnumerable<HighScore>> GetAllScore()
        => await highScoreRepository.GetAllScore();

    public async Task<HighScore?> GetScoreById(Guid scoreId)
        => await highScoreRepository.GetScoreById(scoreId);

    // TODO : Terminar essa func
    public async Task<HighScore?> GetScoreByPlayerId(Guid playerId)
        => await highScoreRepository.GetScoreByPlayerId(playerId);
    
    
    public async Task<bool> CreateScore(HighScore score)
    {
        await highScoreRepository.CreateScore(score);
        await appDbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> UpdateScore(HighScore score)
    {
        var oldScore = await highScoreRepository.GetScoreById(score.Id);
        if (oldScore != null && oldScore.Value > score.Value) return false;
        highScoreRepository.UpdateScore(score);
        await appDbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> RemoveScore(HighScore score)
    {
        highScoreRepository.RemoveScore(score);
        await appDbContext.SaveChangesAsync();
        return true;
    }
}