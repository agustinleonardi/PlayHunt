namespace F2kProject.Application.Abstractions;

using F2kProject.Domain.Models;

public interface IGamesService
{
    Task<List<Game>> GetGamesAsync(string? genre = null, string? platform = null, string? sort = null);
    Task<Game?> GetGameByIdAsync(int id);

}