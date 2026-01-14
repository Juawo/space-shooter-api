using Microsoft.AspNetCore.Mvc;
using SpaceShooterApi.DTOs.PlayerDtos;
using SpaceShooterApi.Mappers;
using SpaceShooterApi.Services;

namespace SpaceShooterApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerController(PlayerService playerService) : ControllerBase
{
    private readonly PlayerService _playerService = playerService;

    [HttpGet]
    public async Task<IActionResult> GetAllPlayers()
    {
        var players = (await _playerService.GetAllPlayers()).Select(player => player.ToPlayerDto());
        return Ok(players);
    }

    [HttpGet("{playerId:guid}")]
    public async Task<IActionResult> GetPlayerById([FromRoute] Guid playerId)
    {
        var player = await _playerService.GetPlayerById(playerId);
        if(player == null) return NotFound();
        return Ok(player.ToPlayerDto()) ;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerRequestDto createPlayerDto)
    {
        var player = createPlayerDto.ToPlayerFromCreateDto();
        await _playerService.CreatePlayer(player);
        return CreatedAtAction(nameof(GetPlayerById), new { id = player.Id }, player.ToPlayerDto());
    }

    [HttpPut("{playerId:guid}")]
    public async Task<IActionResult> UpdatePlayer([FromRoute] Guid playerId,
        [FromBody] UpdatePlayerRequestDto updatePlayerDto)
    {
        var player = await _playerService.GetPlayerById(playerId);
        if (player == null) return NotFound();
        
        player.Nickname = updatePlayerDto.Nickname;
        player.Age = updatePlayerDto.Age;
        player.Country = updatePlayerDto.Country;
        
        await _playerService.UpdatePlayer(player);
        return NoContent();
    }

    [HttpDelete("{playerId:guid}")]
    public async Task<IActionResult> DeletePlayer([FromRoute] Guid playerId)
    {
        var player = await _playerService.GetPlayerById(playerId);
        if (player == null) return NotFound();
        await _playerService.DeletePlayer(player);
        return NoContent();
    }
    
}