using System.ComponentModel.DataAnnotations;

namespace SpaceShooterApi.Models;

public class Player
{
    [Key]
    public required Guid Id { get;  set; }
    public required  string Nickname { get;  set; }
    public required int Age { get;  set; }
    public required string Country { get; set; }

    public Player(Guid id, string nickname, int age, string country)
    {
        Id = id;
        Nickname = nickname;
        Age = age;
        Country = country;
    }
    
}