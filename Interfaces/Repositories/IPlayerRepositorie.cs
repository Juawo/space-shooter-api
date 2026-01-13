using SpaceShooterApi.Models;

namespace SpaceShooterApi.Interfaces.Repositories;

public interface IPlayerRepositorie
{
    Task<IEnumerable<Player>> GetAllPlayer();
    Task<Player?> GetPlayerById(Guid playerId);
    Task<bool> CreatePlayer(Player player);
    Task<bool> UpdatePlayer(Player player);
    Task<bool> DeletePlater(Guid player);

}