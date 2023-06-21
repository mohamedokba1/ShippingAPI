using AutoMapper;
using AutoMapper.Execution;
using Microsoft.Data.SqlClient;
using Shipping.Entities.Domain.Models;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.SalesDtos;
using System.Diagnostics;

using Shipping.Entities.Domain.Identity;
namespace Shipping.Services.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TraderUpdateDto, Trader>().ReverseMap();
        CreateMap<TraderResponseDto, Trader>().ReverseMap();
        CreateMap<TraderAddDto, Trader>().ReverseMap();
        CreateMap<ApplicationUser, TraderAddDto>().ReverseMap();
        CreateMap<ApplicationUser, TraderUpdateDto>().ReverseMap();


        CreateMap<Employee, EmployeeReadDto>()
           .ForMember(dest => dest.Branch, src => src.MapFrom(src => src.branch))
           .ForMember(dest => dest.Privellage, src => src.MapFrom(src => src.Privillage))
            .ReverseMap();

          

        CreateMap<EmployeeAddDto, Employee>()
         .ForMember(dest=>dest.branchid,src=>src.MapFrom(src=>src.branchid))
         .ForMember(dest=>dest.privillageid,src=>src.MapFrom(src=>src.Privellge_Id)).ReverseMap();

        CreateMap<EmployeeupdateDto, Employee>()
            .ForMember(dest => dest.branchid, src => src.MapFrom(src => src.branchid))
         .ForMember(dest => dest.privillageid, src => src.MapFrom(src => src.Privellge_Id)).ReverseMap();




        CreateMap<GovermentReadDto, Goverment>().ReverseMap();
        CreateMap<GovermentAddDto, Goverment>().ReverseMap();
        CreateMap<GovermentUpdateDto, Goverment>().ReverseMap();

        CreateMap<BranchReadDto, Branch>().ReverseMap();
        CreateMap<BranchAddDto, Branch>().ReverseMap();
        CreateMap<BranchUpdateDto, Branch>().ReverseMap();

        CreateMap<CityReadDto, City>().ReverseMap();
        CreateMap<CityAddDto, City>().ReverseMap();
        CreateMap<CityUpdateDto, City>().ReverseMap();

        CreateMap<CustomerReadDto, Customer>().ReverseMap();
        CreateMap<CustomerAddDto, Customer>().ReverseMap();
        CreateMap<CustomerUpdateDto, Customer>().ReverseMap();

        CreateMap<ProductResponseDto, Product>().ReverseMap();
        CreateMap<ProductUpdateDto, Product>().ReverseMap();
        CreateMap<ProductAddDto,Product>().ReverseMap();

        CreateMap<SalesDeletDtos, SalesRepresentative>().ReverseMap();

        CreateMap<SalesReadDtos, SalesRepresentative>().
            ForPath(dest => dest.User.UserName, opt => opt.MapFrom(opt => opt.UserName))
            .ForPath(dest => dest.User.PhoneNumber, opt => opt.MapFrom(opt => opt.PhoneNumber))
             .ForPath(dest => dest.User.Email, opt => opt.MapFrom(opt => opt.Email))
             .ReverseMap();
        
        CreateMap<SalesUpdateDtos, SalesRepresentative>().
            ForPath(dest => dest.User.UserName, opt => opt.MapFrom(opt => opt.UserName))
            .ForPath(dest => dest.User.PhoneNumber, opt => opt.MapFrom(opt => opt.PhoneNumber))
             .ForPath(dest => dest.User.Email, opt => opt.MapFrom(opt => opt.Email))
             .ReverseMap();



        CreateMap<AddSalesDto, SalesRepresentative>().ReverseMap();

        CreateMap<OrderResponseDto, Order>().ReverseMap();
        CreateMap<OrderAddDto, Order>().ReverseMap();
        CreateMap<OrderUpdateDto, Order>().ReverseMap();

        CreateMap<BranchReadDto , Branch>().ReverseMap();

        CreateMap<Privellge , PrivellageDto>().ReverseMap();
        CreateMap<PrivilegeAddDto,Privellge>().ReverseMap();
        CreateMap<PrivllageUpdateDto, Privellge>().ReverseMap();


       
    }
}
