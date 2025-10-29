using AutoMapper;
using F2kProject.Domain.Models;
using F2kProject.Infrastructure.DTOs;

namespace F2kProject.Infrastructure.Mappings;

public class GameMappingProfile : Profile
{
    public GameMappingProfile()
    {
        CreateMap<GameDto, Game>();
    }
}

