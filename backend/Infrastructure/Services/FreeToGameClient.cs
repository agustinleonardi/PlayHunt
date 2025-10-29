using System.Net.Http.Json;
using AutoMapper;
using F2kProject.Application.Abstractions;
using F2kProject.Domain.Models;
using F2kProject.Infrastructure.DTOs;

namespace F2kProject.Infrastructure.Services;

public class FreeToGameClient : IFreeToGameClient
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;

    public FreeToGameClient(HttpClient httpClient, IMapper mapper)
    {
        _httpClient = httpClient;
        _mapper = mapper;
        _httpClient.BaseAddress = new Uri("https://www.freetogame.com/api/");
    }

    public async Task<Game?> GetGameByIdAsync(int id)
    {
        try
        {
            var dto = await _httpClient.GetFromJsonAsync<GameDto>($"game?id={id}");

            if (dto == null)
                return null;

            return _mapper.Map<Game>(dto);
        }
        catch
        {
            return null;
        }
    }

    public async Task<List<Game>> GetGamesAsync()
    {
        try
        {
            var dtos = await _httpClient.GetFromJsonAsync<List<GameDto>>("games");

            if (dtos == null)
                return new List<Game>();

            return _mapper.Map<List<Game>>(dtos);
        }
        catch
        {
            return new List<Game>();
        }
    }
}