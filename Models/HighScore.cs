using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SpaceShooterApi.Models;

[Index(nameof(PlayerId), IsUnique = true)]
public class HighScore
{
    [Key] public Guid Id { get; set; }
    public Guid PlayerId { get;  set; }
    public Player Player { get;  set; }
    public required long Value { get;  set; }
    public DateTime UpdatedAt { get;  set; }

    public HighScore()
    {
        
    }
    
    public HighScore(long value)
    {
        Value = value;
    }
    
}