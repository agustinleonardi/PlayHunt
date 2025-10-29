using F2kProject.Domain.Models;

namespace F2kProject.Application.Abstractions;

public interface IFreeToGameClient
{
    Task<List<Game>> GetGamesAsync();
    Task<Game?> GetGameByIdAsync(int id);
}