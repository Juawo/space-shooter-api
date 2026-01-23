using System.ComponentModel.DataAnnotations;

namespace SpaceShooterApi.Models;

public class Player
{
    [Key]
    public Guid Id { get;  set; }
    public required  string Nickname { get;  set; }
    public required int Age { get;  set; }
    public required string Country { get; set; }
    public HighScore HighScore { get;  set; }

    public Player()
    {
        
    }

    public Player(string nickname, int age, string country)
    {
        Nickname = nickname;
        Age = age;
        Country = country;
    }
    
}