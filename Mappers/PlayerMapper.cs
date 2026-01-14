using SpaceShooterApi.DTOs.Player;
using SpaceShooterApi.DTOs.PlayerDtos;
using SpaceShooterApi.Models;

namespace SpaceShooterApi.Mappers;

public static class PlayerMapper
{
    public static PlayerDto ToPlayerDto(this Player player)
    {
        return new PlayerDto
        (
           player.Nickname,
           player.Country
        );
    }

    public static Player ToPlayerFromCreateDto(this CreatePlayerRequestDto playerCreateDto)
    {
        return new Player
        {
            Nickname = playerCreateDto.Nickname,
            Age = playerCreateDto.Age,
            Country = playerCreateDto.Country
        };
    }
}