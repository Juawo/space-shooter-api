using SpaceShooterApi.Database;
using SpaceShooterApi.DTOs.PlayerDtos;
using SpaceShooterApi.Interfaces.Repositories;
using SpaceShooterApi.Models;
using SpaceShooterApi.Repositories;

namespace SpaceShooterApi.Services;
public class PlayerService(IPlayerRepository repository)
{
    private readonly IPlayerRepository _repository = repository;

    public async Task<Result<Player?>> CreatePlayer(Player player)
    {
        var existingPlayer = await _repository.GetPlayerByNickname(player.Nickname);
        if (existingPlayer != null)
            return Result<Player?>.Failure(ErrorType.Conflict);

        if (player.Nickname.Length < 3 || player.Nickname.Length > 12 || player.Age <= 5 || player.Age > 100)
            return Result<Player?>.Failure(ErrorType.ValidationError);

        await _repository.CreatePlayer(player);
        return Result<Player?>.Ok(player);
    }

    public async Task<Result<Player?>> GetPlayerById(Guid playerId)
    {
        var player = await _repository.GetPlayerById(playerId);
        return player == null ? 
            Result<Player?>.Failure(ErrorType.NotFound) : 
            Result<Player?>.Ok(player);
    }

    public async Task<Result<IEnumerable<Player?>>> GetAllPlayers()
    {
        var players = (await _repository.GetAllPlayers()).ToList(); 
        
        return players.Count == 0 ?
            Result<IEnumerable<Player?>>.Failure(ErrorType.NotFound) :
            Result<IEnumerable<Player?>>.Ok(players);
    }

    public async Task<Result<bool>> UpdatePlayer(Player player)
    {
        var nicknameConflict = await _repository.NicknameExistsForAnotherPlayer(player.Nickname, player.Id);
    
        if (nicknameConflict)
        {
            return Result<bool>.Failure(ErrorType.Conflict);
        }

        if (player.Nickname.Length < 3 || player.Age <= 5 || player.Age > 100)
        {
            return Result<bool>.Failure(ErrorType.ValidationError);
        }
    
        await _repository.UpdatePlayer(player);
        return Result<bool>.Ok(true);
    }
    
    public async Task<Result<bool>> UpdatePlayerNickname(Guid playerId, string nickname)
    {
        var player = await _repository.GetPlayerById(playerId);
        if (player == null)
            return Result<bool>.Failure(ErrorType.NotFound);

        if (nickname.Length < 3 || nickname.Length > 12)
            return Result<bool>.Failure(ErrorType.ValidationError);
        
        var uniqueNickname = await _repository.GetPlayerByNickname(nickname);
        if (uniqueNickname != null)
            return Result<bool>.Failure(ErrorType.Conflict);

        player.Nickname = nickname;
        await _repository.UpdatePlayer(player);
        return Result<bool>.Ok(true);
    }

    public async Task<Result<bool>> RemovePlayer(Guid playerId)
    {
        var player = await _repository.GetPlayerById(playerId);
        if (player == null)
            return Result<bool>.Failure(ErrorType.NotFound);

        await _repository.RemovePlayer(player);
        return Result<bool>.Ok(true);
    }
}