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
           .ForMember(dest => dest.Branch, src => src.MapFrom(src => src.Branch))
            .ReverseMap();



        CreateMap<EmployeeAddDto, Employee>()
         .ForMember(dest => dest.branchid, src => src.MapFrom(src => src.branchid));

        CreateMap<EmployeeupdateDto, Employee>()
            .ForMember(dest => dest.branchid, src => src.MapFrom(src => src.branchid)).ReverseMap();

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


        CreateMap<Order, OrderResponseDto>()
            .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod.ToString()))
            .ForMember(dest => dest.ShippingType, opt => opt.MapFrom(src => src.ShippingType.ToString()))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State.ToString()));
        CreateMap<OrderResponseDto, Order>()
            .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => Enum.Parse(typeof(PaymentType), src.PaymentMethod)))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => Enum.Parse(typeof(OrderState), src.State)))
            .ForMember(dest => dest.ShippingType, opt => opt.MapFrom(src => Enum.Parse(typeof(ShippingType), src.ShippingType)));
        CreateMap<OrderAddDto, Order>().ReverseMap();
        CreateMap<OrderUpdateDto, Order>()
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => Enum.Parse(typeof(OrderState), src.State)));


        CreateMap<BranchReadDto , Branch>().ReverseMap();
        CreateMap<PermissionResponseDto, ApplicationUserRole>().ReverseMap();
    }
}
