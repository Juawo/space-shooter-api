using Microsoft.AspNetCore.Mvc;
using SpaceShooterApi.DTOs.HighScoreDtos;
using SpaceShooterApi.Mappers;
using SpaceShooterApi.Models;
using SpaceShooterApi.Services;

namespace SpaceShooterApi.Controllers;
// TODO : Todas as rotas de Score precisam do ID de um player
[Route("api/[controller]")]
[ApiController]
public class HighScoreController : ControllerBase
{
    private readonly PlayerService _playerService;
    private readonly HighScoreService _highScoreService;

    public HighScoreController(HighScoreService highScoreService, PlayerService playerService)
    {
        _highScoreService = highScoreService;
        _playerService = playerService;
    }

    [HttpGet("{playerId:guid}")]
    public async Task<IActionResult> GetAllScores(Guid playerId)
    {
        var scoresResult = await _highScoreService.GetAllScore(playerId);

        return scoresResult.Error == ErrorType.None
            ? Ok(scoresResult.Data.Where(s => s != null).Select(s => s.ToScoreDto()))
            : NotFound();
    }

    [HttpGet("leaderboard/{playerId:guid}")]
    public async Task<IActionResult> GetLeaderboard([FromRoute] Guid playerId)
    {
        var scoresResult = await _highScoreService.GetScoresWithPlayers(playerId);
        
        return scoresResult.Error == ErrorType.None
                ? Ok(scoresResult.Data.Select(s => s.ToScoreDto()))
                : NotFound();
    }

    [HttpGet("{playerId:guid}/{scoreId:guid}")]
    public async Task<IActionResult> GetScoreById([FromRoute] Guid scoreId, [FromRoute] Guid playerId)
    {
        var scoreResult = await  _highScoreService.GetScoreById(scoreId, playerId);
        return scoreResult.Error == ErrorType.None ?
                Ok(scoreResult.Data.ToScoreDto()) :
                NotFound();
    }

    [HttpPost("{playerId:guid}")]
    public async Task<IActionResult> CreateScore([FromBody] CreateHighScoreRequestDto createHighScoreDto, [FromRoute] Guid playerId)
    {
        var score = createHighScoreDto.ToScoreFromCreateScoreDto(); 
        score.PlayerId = playerId;
        score.UpdatedAt = DateTime.UtcNow;
        
        var createResult = await _highScoreService.CreateScore(score);
        return createResult.Error == ErrorType.None ?
            CreatedAtAction(nameof(GetScoreById), new { scoreId = score.Id }, score.ToScoreDto()) :
            NotFound();
    }

    [HttpPatch("{playerId:guid}/{scoreId:guid}")]
    public async Task<IActionResult> UpdateScoreValue([FromRoute] Guid playerId, [FromRoute] Guid scoreId,
        [FromBody] UpdateHighScoreRequestDto highScoreValueDto)
    {
        var updateResult = await  _highScoreService.UpdateScoreValue(playerId, scoreId, highScoreValueDto.Value);
        return updateResult.Error switch
        {
            ErrorType.None => NoContent(),
            ErrorType.NotFound => NotFound(),
            ErrorType.ValidationError => ValidationProblem()
        };

    }
    
    [HttpDelete("{playerId:guid}/{scoreId:guid}")]
    public async Task<IActionResult> DeleteScore([FromRoute] Guid playerId, [FromRoute] Guid scoreId)
    {
        var removeResult = await _highScoreService.RemoveScore(playerId, scoreId);
        
        return removeResult.Error == ErrorType.None ?
                NoContent() :
                NotFound("Score not found");
    }
}