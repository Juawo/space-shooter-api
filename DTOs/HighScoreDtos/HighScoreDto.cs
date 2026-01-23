namespace SpaceShooterApi.DTOs.HighScoreDtos;

public record HighScoreDto(
    Guid PlayerId,
    long Value,
    DateTime UpdatedAt
    );