namespace SpaceShooterApi.DTOs.ScoreDtos;

public record CreateScoreRequestDto(
    Guid PlayerId,
    long Value
    );