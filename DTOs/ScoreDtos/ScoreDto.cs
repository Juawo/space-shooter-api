namespace SpaceShooterApi.DTOs.ScoreDtos;

public record ScoreDto(
    Guid PlayerId,
    long Value,
    DateTime CreatedAt,
    DateTime UpdatedAt
    );