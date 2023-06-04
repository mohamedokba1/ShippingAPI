using AutoMapper;
using Shipping.Entities.Domain.Models;
using Shipping.Services.Dtos;

namespace Shipping.Services.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TraderAddDto, Trader>().ReverseMap();
        CreateMap<TraderUpdateDto, Trader>().ReverseMap();
        CreateMap<TraderResponseDto, Trader>().ReverseMap();

        CreateMap<EmployeeReadDto, Employee>().ReverseMap();
        CreateMap<EmployeeAddDto, Employee>().ReverseMap();
        CreateMap<EmployeeupdateDto, Employee>().ReverseMap();

        CreateMap<GovermentReadDto, Goverment>().ReverseMap();
        CreateMap<GovermentAddDto, Goverment>().ReverseMap();
        CreateMap<GovermentUpdateDto, Goverment>().ReverseMap();

        CreateMap<CityReadDto, City>().ReverseMap();
        CreateMap<CityAddDto, City>().ReverseMap();
        CreateMap<CityUpdateDto, City>().ReverseMap();
        CreateMap<CityDeleteDto, City>().ReverseMap();

        CreateMap<CustomerReadDto, Customer>().ReverseMap();
        CreateMap<CustomerAddDto, Customer>().ReverseMap();
        CreateMap<CustomerUpdateDto, Customer>().ReverseMap();
        CreateMap<CustomerDeleteDto, Customer>().ReverseMap();

    }
}
