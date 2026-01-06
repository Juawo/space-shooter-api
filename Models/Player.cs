namespace SpaceShooterApi.Models;

public class Player
{
    public Guid Id { get; private set; }
    public string Nickname { get; private set; }
    public int Age { get; private set; }
    public string Country { get; private set; }

    public Player(Guid id, string nickname, int age, string country)
    {
        Id = id;
        Nickname = nickname;
        Age = age;
        Country = country;
    }
    
}