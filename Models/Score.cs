using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceShooterApi.Models;

public class Score
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey(nameof(PlayerId))]
    public required  Guid PlayerId { get;  set; }
    public required  long Value { get;  set; }
    public DateTime CreatedAt { get;  set; }
    public DateTime UpdatedAt { get;  set; }

    public Score()
    {
        
    }
    
    public Score(Guid playerId, long value)
    {
        PlayerId = playerId;
        Value = value;
    }
}