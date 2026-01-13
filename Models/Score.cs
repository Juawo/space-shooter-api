using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceShooterApi.Models;

public class Score
{
    [Key]
    public required Guid Id { get; set; }
    [ForeignKey(nameof(PlayerId))]
    public required  Guid PlayerId { get;  set; }
    public required  long Value { get;  set; }
    public required DateTime CreatedAt { get;  set; }
    
    public Score(Guid id, Guid playerId, long value, DateTime createdAt)
    {
        Id = id;
        PlayerId = playerId;
        Value = value;
        CreatedAt = createdAt;
    }
}