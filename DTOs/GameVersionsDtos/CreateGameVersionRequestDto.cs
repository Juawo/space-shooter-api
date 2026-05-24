namespace SpaceShooterApi.DTOs.GameVersionsDtos;

public record CreateGameVersionRequestDto(
    string CurrentVersion,
    string DownloadUrl,
    bool IsMandatory
);