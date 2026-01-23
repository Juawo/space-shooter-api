using SpaceShooterApi.DTOs.HighScoreDtos;
using SpaceShooterApi.Models;

namespace SpaceShooterApi.Mappers;

public static class HighScoreMapper
{

    public static HighScoreDto ToScoreDto(this HighScore score)
    {
        return new HighScoreDto(
            score.PlayerId,
            score.Value,
            score.UpdatedAt
        );
    }

    public static HighScore ToScoreFromCreateScoreDto(this CreateHighScoreRequestDto highScoreDto)
    {
        return new HighScore
        {
            Value = highScoreDto.Value
        };
    }
}