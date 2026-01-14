namespace SpaceShooterApi.DTOs.PlayerDtos;

public record CreatePlayerRequestDto(
    string Nickname,
    string Country,
    int Age
    );