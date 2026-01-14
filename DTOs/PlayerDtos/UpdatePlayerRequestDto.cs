namespace SpaceShooterApi.DTOs.PlayerDtos;

public record UpdatePlayerRequestDto(
    string Nickname,
    string Country,
    int Age
);