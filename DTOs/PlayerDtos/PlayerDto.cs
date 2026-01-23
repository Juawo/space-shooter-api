namespace SpaceShooterApi.DTOs.Player;

public record PlayerDto(
        Guid PlayerId,
        string Nickname,
        string Country
    );