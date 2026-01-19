using SpaceShooterApi.DTOs.ScoreDtos;
using SpaceShooterApi.Models;

namespace SpaceShooterApi.Mappers;

public static class ScoreMapper
{

    public static ScoreDto ToScoreDto(this Score score)
    {
        return new ScoreDto(
            score.PlayerId,
            score.Value,
            score.CreatedAt,
            score.UpdatedAt
        );
    }

    public static Score ToScoreFromCreateScore(this CreateScoreRequestDto scoreDto)
    {
        return new Score
        {
            PlayerId = scoreDto.PlayerId,
            Value = scoreDto.Value,
        };
    }
}