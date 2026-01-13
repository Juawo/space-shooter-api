using SpaceShooterApi.Models;

namespace SpaceShooterApi.Interfaces.Repositories;

public interface IPlayerRepository
{
    Task<IEnumerable<Player>> GetAllPlayers();
    Task<Player?> GetPlayerById(Guid playerId);
    Task CreatePlayer(Player player);
    void UpdatePlayer(Player player);
    void RemovePlayer(Player player);

}