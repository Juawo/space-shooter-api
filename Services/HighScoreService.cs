using SpaceShooterApi.Database;
using SpaceShooterApi.Interfaces.Repositories;
using SpaceShooterApi.Models;

namespace SpaceShooterApi.Services;

public class HighScoreService(IHighScoreRepository highScoreRepository, IPlayerRepository playerRepository)
{
    public async Task<Result<IEnumerable<HighScore?>>> GetAllScore(Guid playerId)
    {
        var existPlayer = await playerRepository.GetPlayerById(playerId);
        if (existPlayer == null) return Result<IEnumerable<HighScore?>>.Failure(ErrorType.NotFound);

        var highScores = (await highScoreRepository.GetAllScore()).ToList();
        return highScores.Count != 0 ?
            Result<IEnumerable<HighScore?>>.Ok(highScores) :
            Result<IEnumerable<HighScore?>>.Failure(ErrorType.NotFound);
    }

    public async Task<Result<HighScore?>> GetScoreById(Guid scoreId, Guid playerId)
    {
        var existPlayer = await playerRepository.GetPlayerById(playerId);
        if (existPlayer == null) return Result<HighScore?>.Failure(ErrorType.NotFound);

        var highScore = await highScoreRepository.GetScoreById(scoreId);
        return highScore != null ?
            Result<HighScore?>.Ok(highScore) :
            Result<HighScore?>.Failure(ErrorType.NotFound);
    }

    public async Task<Result<HighScore?>> GetScoreByPlayerId(Guid playerId)
    {
        var highScore = await highScoreRepository.GetScoreByPlayerId(playerId);
        return highScore != null ?
            Result<HighScore?>.Ok(highScore) :
            Result<HighScore?>.Failure(ErrorType.NotFound);
    }

    public async Task<Result<List<HighScore>>> GetScoresWithPlayers(Guid playerId)
    {
        var existPlayer = await playerRepository.GetPlayerById(playerId);
        if (existPlayer == null) return Result<List<HighScore>>.Failure(ErrorType.NotFound);

        var highScores = await highScoreRepository.GetScoresWithPlayers();
        return  highScores.Count == 0 ?
            Result<List<HighScore>>.Failure(ErrorType.NotFound) :
            Result<List<HighScore>>.Ok(highScores);
    }
    
    public async Task<Result<bool>> CreateScore(HighScore score)
    {
        var existPlayer = await playerRepository.GetPlayerById(score.PlayerId);
        if (existPlayer == null) return Result<bool>.Failure(ErrorType.NotFound);
        
        var existHighScore = await highScoreRepository.GetScoreById(score.Id);
        if (existHighScore == null) return Result<bool>.Failure(ErrorType.NotFound);
        await highScoreRepository.CreateScore(score);
        
        return Result<bool>.Ok(true);
    }
    
    public async Task<Result<bool>> UpdateScoreValue(Guid playerId, Guid highScoreId, long value)
    {
        var oldScore = await highScoreRepository.GetScoreById(highScoreId);
        if(oldScore == null)  return Result<bool>.Failure(ErrorType.NotFound);
        if (oldScore.Value > value || oldScore.PlayerId != playerId) return Result<bool>.Failure(ErrorType.ValidationError);
        
        oldScore.Value = value;
        await highScoreRepository.UpdateScore(oldScore);
        
        return Result<bool>.Ok(true);
    }
    public async Task<Result<bool>> UpdateScore(HighScore score)
    {
        var oldScore = await highScoreRepository.GetScoreById(score.Id);
        if(oldScore == null)  return Result<bool>.Failure(ErrorType.NotFound);
        if (oldScore.Value > score.Value) return Result<bool>.Failure(ErrorType.ValidationError);
        await highScoreRepository.UpdateScore(score);
        return Result<bool>.Ok(true);
    }
    
    public async Task<Result<bool>> RemoveScore(Guid playerId, Guid scoreId)
    {   
        var existPlayer = await playerRepository.GetPlayerById(playerId);
        if (existPlayer == null) return Result<bool>.Failure(ErrorType.NotFound);
        
        var existHighScore = await highScoreRepository.GetScoreById(scoreId);
        if (existHighScore == null) return Result<bool>.Failure(ErrorType.NotFound);
        
        await highScoreRepository.RemoveScore(existHighScore);
        return Result<bool>.Ok(true);
    }
}