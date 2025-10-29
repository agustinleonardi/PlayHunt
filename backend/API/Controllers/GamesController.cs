using F2kProject.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGamesService _gamesService;

    public GamesController(IGamesService gamesService)
    {
        _gamesService = gamesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetGames([FromQuery] string? genre, [FromQuery] string? platform, [FromQuery] string? sort)
    {
        var games = await _gamesService.GetGamesAsync(genre, platform, sort);

        Console.WriteLine($"Games count: {games?.Count ?? 0}");


        return Ok(games);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGameById(int id)
    {
        var game = await _gamesService.GetGameByIdAsync(id);

        if (game is null)
            return NotFound();

        return Ok(game);
    }
}

