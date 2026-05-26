using Microsoft.AspNetCore.Mvc;
using SpaceShooterApi.DTOs.GameVersionsDtos;
using SpaceShooterApi.Mappers;
using SpaceShooterApi.Models;
using SpaceShooterApi.Services;

namespace SpaceShooterApi.Controllers;

// TODO : Add sample cache!

[Route("api/[controller]")]
[ApiController]
public class GameVersionsController(GameVersionsService gameVersionsService) : ControllerBase
{
    private readonly GameVersionsService _gameVersionsService = gameVersionsService;

    [HttpGet]
    public async Task<IActionResult> GetLatestVersion()
    {
        var result = await _gameVersionsService.GetLatestGameVersion();

        return result.Error switch
        {
            ErrorType.None => Ok(result.Data),
            ErrorType.NotFound => NotFound(),
            _ => BadRequest()
        };
    }

    [HttpGet("{gameVersionsId:guid}")]
    public async Task<IActionResult> GetGameVersionsById([FromRoute] Guid gameVersionsId)
    {
        var result = await _gameVersionsService.GetGameVersionById(gameVersionsId);
        return result.Error switch
        {
            ErrorType.None => Ok(result.Data),
            ErrorType.NotFound => NotFound(),
            _ => BadRequest()
        };
    }

    [HttpPost]
    public async Task<IActionResult> CreateGameVersion(
        [FromBody] CreateGameVersionRequestDto createGameVersionRequestDto)
    {
        var gameVersion = createGameVersionRequestDto.ToGameVersionFromCreateDto();
        var result = await _gameVersionsService.CreateGameVersion(gameVersion);
        return result.Error switch
        {
            ErrorType.None => CreatedAtAction(nameof(GetGameVersionsById), new { gameVersionId = result.Data.Id }),
            ErrorType.Conflict => Conflict(),
            ErrorType.ValidationError => ValidationProblem(),
            _ => BadRequest()
        };
    }
}