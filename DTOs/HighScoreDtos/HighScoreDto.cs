namespace SpaceShooterApi.DTOs.HighScoreDtos;

public record HighScoreDto(
    Guid PlayerId,
    Guid HighScoreId,
    long Value,
    DateTime UpdatedAt
    );