using Microsoft.EntityFrameworkCore;
using SpaceShooterApi.Database;
using SpaceShooterApi.Interfaces.Repositories;
using SpaceShooterApi.Models;

namespace SpaceShooterApi.Repositories;

public class HighScoreRepository(AppDbContext dbContext) : IHighScoreRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<IEnumerable<HighScore>> GetAllScore()
        => await _dbContext.HighScores.ToListAsync();

    public async Task<HighScore?> GetScoreById(Guid scoreId)
        =>  await _dbContext.HighScores.FindAsync(scoreId);

    public async Task<HighScore?> GetScoreByPlayerId(Guid playerId)
        => await _dbContext.HighScores.FirstOrDefaultAsync(score => score.PlayerId == playerId);
    
    // TODO : Revise the performance in this function
    public async Task<List<HighScore>> GetScoresWithPlayers()
    {
        return await _dbContext.HighScores
            .AsNoTracking()
            .Include(score => score.Player)
            .OrderByDescending(score => score.Value)
            .Take(20)
            .ToListAsync();
    }

    public async Task CreateScore(HighScore score)
    {
        await _dbContext.HighScores.AddAsync(score);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task UpdateScore(HighScore score)
    {
        _dbContext.HighScores.Update(score);
        await  _dbContext.SaveChangesAsync();
    }

    public async Task RemoveScore(HighScore score)
    {
        _dbContext.HighScores.Remove(score);
        await _dbContext.SaveChangesAsync();
    }
}