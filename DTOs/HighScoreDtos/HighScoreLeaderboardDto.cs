namespace SpaceShooterApi.DTOs.HighScoreDtos;

public record HighScoreLeaderboardDto(
    string PlayerNickname,
    long HighScoreValue,
    DateTime UpdatedAt
    );