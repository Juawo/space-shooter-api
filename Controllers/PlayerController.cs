using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceShooterApi.DTOs.PlayerDtos;
using SpaceShooterApi.Mappers;
using SpaceShooterApi.Models;
using SpaceShooterApi.Services;

namespace SpaceShooterApi.Controllers;

// TODO : Ajustar CONTROLLER para utilizar ResultObject

[Route("api/[controller]")]
[ApiController]
public class PlayerController(PlayerService playerService) : ControllerBase
{
    private readonly PlayerService _playerService = playerService;

    [HttpGet]
    public async Task<IActionResult> GetAllPlayers()
    {
        var result = await _playerService.GetAllPlayers();
        
        return result.Error switch
        {
            ErrorType.None => Ok(result.Data.Select(player => player.ToPlayerDto())),
            ErrorType.NotFound => NotFound(),
            _ => BadRequest()
        };
    }

    [HttpGet("{playerId:guid}")]
    public async Task<IActionResult> GetPlayerById([FromRoute] Guid playerId)
    {
        var result = await _playerService.GetPlayerById(playerId);

        return result.Error switch
        {
            ErrorType.None => Ok(result.Data.ToPlayerDto()),
            ErrorType.NotFound => NotFound(),
            _ => BadRequest()
        };
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerRequestDto createPlayerDto)
    {
        var player = createPlayerDto.ToPlayerFromCreateDto();
        var result = await _playerService.CreatePlayer(player);
        return result.Error switch
        {
            ErrorType.None => CreatedAtAction(nameof(GetPlayerById), new { playerId = result.Data.Id },
                result.Data.ToPlayerDto()),
            ErrorType.Conflict => Conflict(),
            ErrorType.ValidationError => ValidationProblem(),
            _ => BadRequest()
        };
    }

    [HttpPut("{playerId:guid}")]
    public async Task<IActionResult> UpdatePlayer([FromRoute] Guid playerId,
        [FromBody] UpdatePlayerRequestDto updatePlayerDto)
    {
        var result = await _playerService.GetPlayerById(playerId);
        if (result.Error == ErrorType.NotFound) return NotFound();
        
        result.Data.Nickname = updatePlayerDto.Nickname;
        result.Data.Age = updatePlayerDto.Age;
        result.Data.Country = updatePlayerDto.Country;
        
        var updateResult = await _playerService.UpdatePlayer(result.Data);
        return updateResult.Error switch
        {
            ErrorType.None => NoContent(),
            ErrorType.Conflict => Conflict(),
            ErrorType.ValidationError => ValidationProblem(),
            _ => BadRequest()
        };
    }

    [HttpPatch("{playerId:guid}")]
    public async Task<IActionResult> UpdatePlayerNickname([FromRoute] Guid playerId,
        [FromBody] UpdatePlayerNicknameRequestDto updatePlayerNickname)
    {
        var result = await _playerService.UpdatePlayerNickname(playerId, updatePlayerNickname.Nickname);
        return result.Error switch
        {
            ErrorType.None => NoContent(),
            ErrorType.NotFound => NotFound(),
            ErrorType.Conflict => Conflict(),
            ErrorType.ValidationError => ValidationProblem(),
            _ => BadRequest()
        };
    }

    [HttpDelete("{playerId:guid}")]
    public async Task<IActionResult> DeletePlayer([FromRoute] Guid playerId)
    {
        var result = await _playerService.RemovePlayer(playerId);
        return result.Error switch
        {
            ErrorType.None => NoContent(),
            ErrorType.NotFound => NotFound(),
            _ => BadRequest()
        };
    }
    
}