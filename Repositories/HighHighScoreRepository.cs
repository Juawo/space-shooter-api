using Microsoft.EntityFrameworkCore;
using SpaceShooterApi.Database;
using SpaceShooterApi.Interfaces.Repositories;
using SpaceShooterApi.Models;

namespace SpaceShooterApi.Repositories;

public class HighHighScoreRepository(AppDbContext dbContext) : IHighScoreRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<IEnumerable<HighScore>> GetAllScore()
        => await _dbContext.HighScores.ToListAsync();

    public async Task<HighScore?> GetScoreById(Guid scoreId)
        =>  await _dbContext.HighScores.FindAsync(scoreId);

    public async Task<HighScore?> GetScoreByPlayerId(Guid playerId)
        => await _dbContext.HighScores.FirstOrDefaultAsync(score => score.PlayerId == playerId);

    public async Task CreateScore(HighScore score)
        => await _dbContext.HighScores.AddAsync(score);

    public void UpdateScore(HighScore score)
        =>  _dbContext.HighScores.Update(score);
    
    public void RemoveScore(HighScore score)
        => _dbContext.HighScores.Remove(score);
}