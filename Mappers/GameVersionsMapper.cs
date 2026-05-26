using SpaceShooterApi.DTOs.GameVersionsDtos;
using SpaceShooterApi.Models;

namespace SpaceShooterApi.Mappers;

public static class GameVersionsMapper
{
    public static GameVersion ToGameVersionFromCreateDto(this CreateGameVersionRequestDto createGameVersionRequestDto)
    {
        return new GameVersion
        {
            CurrentVersion = createGameVersionRequestDto.CurrentVersion,
            DownloadUrl = createGameVersionRequestDto.DownloadUrl,
            IsMandatory = createGameVersionRequestDto.IsMandatory,
        };
    }
}