using F2kProject.Application.Abstractions;
using F2kProject.Domain.Models;

namespace F2kProject.Application.Services;

public class GamesService : IGamesService
{
    private readonly IFreeToGameClient _freeToGameClient;
    private readonly ICacheService _cacheService;

    public GamesService(IFreeToGameClient freeToGameClient, ICacheService cacheService)
    {
        _cacheService = cacheService;
        _freeToGameClient = freeToGameClient;
    }

    public async Task<Game?> GetGameByIdAsync(int id)
    {
        var cacheKey = $"game_{id}";
        var cachedGame = await _cacheService.GetAsync<Game>(cacheKey);

        if (cachedGame is not null) return cachedGame;

        var game = await _freeToGameClient.GetGameByIdAsync(id);

        if (game is not null) await _cacheService.SetAsync(cacheKey, game, TimeSpan.FromMinutes(30));

        return game;
    }

    public async Task<List<Game>> GetGamesAsync(string? genre = null, string? platform = null, string? sort = null)
    {
        var cacheKey = $"games_{genre}_{platform}_{sort}";
        var cachedGames = await _cacheService.GetAsync<List<Game>>(cacheKey);

        if (cachedGames is not null) return cachedGames;

        var games = await _freeToGameClient.GetGamesAsync();

        // FILTRO POR GÉNERO
        if (!string.IsNullOrEmpty(genre))
            games = games.Where(g => g.Genre?.Equals(genre, StringComparison.OrdinalIgnoreCase) == true).ToList();

        // FILTRO POR PLATAFORMA
        if (!string.IsNullOrEmpty(platform))
            games = games.Where(g => g.Platform?.Equals(platform, StringComparison.OrdinalIgnoreCase) == true).ToList();

        // ORDENAR
        games = sort?.ToLower() switch
        {
            "title" => games.OrderBy(g => g.Title).ToList(),
            "releasedate" => games.OrderByDescending(g => g.ReleaseDate).ToList(),
            _ => games
        };

        await _cacheService.SetAsync(cacheKey, games, TimeSpan.FromMinutes(10));

        return games;
    }
}
