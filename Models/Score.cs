namespace SpaceShooterApi.Models;

public class Score
{
    public Guid Id { get; private set; }
    public Guid PlayerId { get; private set; }
    public long Value { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    public Score(Guid id, Guid playerId, long value, DateTime createdAt)
    {
        Id = id;
        PlayerId = playerId;
        Value = value;
        CreatedAt = createdAt;
    }
}