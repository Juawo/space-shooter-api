using SpaceShooterApi.Models;

namespace SpaceShooterApi.Interfaces.Repositories;

public interface IPlayerRepository
{
    Task<IEnumerable<Player>> GetAllPlayers();
    Task<Player?> GetPlayerById(Guid playerId);
    Task<Player?> GetPlayerByNickname(string nickname);
    Task<bool> NicknameExistsForAnotherPlayer(string nickname, Guid playerId);
    Task CreatePlayer(Player player);
    Task UpdatePlayer(Player player);
    Task RemovePlayer(Player player);

}