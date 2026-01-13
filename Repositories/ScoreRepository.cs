using Microsoft.EntityFrameworkCore;
using SpaceShooterApi.Database;
using SpaceShooterApi.Interfaces.Repositories;
using SpaceShooterApi.Models;

namespace SpaceShooterApi.Repositories;

public class ScoreRepository(AppDbContext dbContext) : IScoreRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<IEnumerable<Score>> GetAllScore()
        => await _dbContext.Scores.ToListAsync();

    public async Task<Score?> GetScoreById(Guid scoreId)
        =>  await _dbContext.Scores.FindAsync(scoreId);

    public async Task CreateScore(Score score)
        => await _dbContext.Scores.AddAsync(score);

    public async void UpdateScore(Score score)
        =>  _dbContext.Scores.Update(score);
    
    public async void RemoveScore(Score score)
        => _dbContext.Scores.Remove(score);
}