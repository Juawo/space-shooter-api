using Microsoft.AspNetCore.Mvc;
using SpaceShooterApi.DTOs.ScoreDtos;
using SpaceShooterApi.Mappers;
using SpaceShooterApi.Services;

namespace SpaceShooterApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ScoreController : ControllerBase
{
    private readonly ScoreService _scoreService;

    public ScoreController(ScoreService scoreService)
    {
        _scoreService = scoreService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllScores()
    {
        var scores = (await _scoreService.GetAllScore()).Select(score => score.ToScoreDto());
        return Ok(scores);
    }

    [HttpGet("{scoreId:guid}")]
    public async Task<IActionResult> GetScoreById([FromRoute] Guid scoreId)
    {
        var score = await  _scoreService.GetScoreById(scoreId);
        if (score == null)  return NotFound();
        return Ok(score.ToScoreDto());
    }

    [HttpPost]
    public async Task<IActionResult> CreateScore([FromBody] CreateScoreRequestDto createScoreDto)
    {
        var score = createScoreDto.ToScoreFromCreateScore(); 
        score.CreatedAt = DateTime.UtcNow;
        score.UpdatedAt = DateTime.UtcNow;
        await _scoreService.CreateScore(score);
        return CreatedAtAction(nameof(GetScoreById), new { scoreId = score.Id }, score.ToScoreDto());
    }

    [HttpPut("{scoreId:guid}")]
    public async Task<IActionResult> UpdateScore([FromRoute] Guid scoreId,
        [FromBody] UpdateScoreRequestDto updateScoreDto)
    {
        var score = await _scoreService.GetScoreById(scoreId);
        if (score == null) return NotFound();
        score.Value = updateScoreDto.Value;
        score.UpdatedAt = DateTime.UtcNow;
        await _scoreService.UpdateScore(score);
        return NoContent();
    }

    [HttpDelete("{scoreId:guid}")]
    public async Task<IActionResult> DeleteScore([FromRoute] Guid scoreId)
    {
        var score = await _scoreService.GetScoreById(scoreId);
        if (score == null) return NotFound();
        await _scoreService.RemoveScore(score);
        return NoContent();
    }
}