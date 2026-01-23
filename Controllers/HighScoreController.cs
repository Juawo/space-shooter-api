using Microsoft.AspNetCore.Mvc;
using SpaceShooterApi.DTOs.HighScoreDtos;
using SpaceShooterApi.Mappers;
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
        var player = await _playerService.GetPlayerById(playerId);
        if (player == null) return NotFound();
        
        var scores = (await _highScoreService.GetAllScore()).Select(score => score.ToScoreDto());
        
        return Ok(scores);
    }

    [HttpGet("{playerId:guid}/{scoreId:guid}")]
    public async Task<IActionResult> GetScoreById([FromRoute] Guid scoreId, [FromRoute] Guid playerId)
    {
        var player = await _playerService.GetPlayerById(playerId);
        if (player == null) return NotFound("Player not found");
        
        var score = await  _highScoreService.GetScoreById(scoreId);
        
        if (score == null)  return NotFound("Score not found");
        return Ok(score.ToScoreDto());
    }

    [HttpPost("{playerId:guid}")]
    public async Task<IActionResult> CreateScore([FromBody] CreateHighScoreRequestDto createHighScoreDto, [FromRoute] Guid playerId)
    {
        var player = await _playerService.GetPlayerById(playerId);
        if (player == null) return NotFound("Player not found");
        
        var existingScore = await _highScoreService.GetScoreByPlayerId(playerId);
        if(existingScore != null)  return Conflict("Score already exists");
        
        var score = createHighScoreDto.ToScoreFromCreateScoreDto(); 
        score.PlayerId = playerId;
        score.UpdatedAt = DateTime.UtcNow;
        
        await _highScoreService.CreateScore(score);
        return CreatedAtAction(nameof(GetScoreById), new { scoreId = score.Id }, score.ToScoreDto());
    }

    [HttpPut("{playerId:guid}/{scoreId:guid}")]
    public async Task<IActionResult> UpdateScore([FromRoute] Guid playerId, [FromRoute] Guid scoreId,
        [FromBody] UpdateHighScoreRequestDto updateHighScoreDto)
    {
        var player = await _playerService.GetPlayerById(playerId);
        if (player == null) return NotFound("Player not found");
        
        var score = await _highScoreService.GetScoreById(scoreId);
        if (score == null) return NotFound("Score not found");
        
        if(score.Value > updateHighScoreDto.Value) 
            return BadRequest("Score value is not bigger than old score! ");
        
        score.Value = updateHighScoreDto.Value;
        score.UpdatedAt = DateTime.UtcNow;
        await _highScoreService.UpdateScore(score);
        return NoContent();
    }
    
    [HttpDelete("{playerId:guid}/{scoreId:guid}")]
    public async Task<IActionResult> DeleteScore([FromRoute] Guid playerId, [FromRoute] Guid scoreId)
    {
        var player = await _playerService.GetPlayerById(playerId);
        if (player == null) return NotFound();
        
        var score = await _highScoreService.GetScoreById(scoreId);
        if (score == null) return NotFound();
        
        await _highScoreService.RemoveScore(score);
        
        return NoContent();
    }
}