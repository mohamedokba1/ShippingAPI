using AutoMapper;
using Shipping.Entities.Models;
using Shipping.Services.Dtos;

namespace Shipping.Services.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TraderAddDto, Trader>();
        CreateMap<TraderUpdateDto, Trader>();
        CreateMap<TraderResponseDto, Trader>();
    }
}
