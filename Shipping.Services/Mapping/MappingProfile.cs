using AutoMapper;
using AutoMapper.Execution;
using Microsoft.Data.SqlClient;
using Shipping.Entities.Domain.Models;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.Branch;
using Shipping.Services.Dtos.ProductDtos;
using Shipping.Services.Dtos.SalesDtos;
using System.Diagnostics;

namespace Shipping.Services.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TraderAddDto, Trader>().ReverseMap();
        CreateMap<TraderUpdateDto, Trader>().ReverseMap();
        CreateMap<TraderResponseDto, Trader>().ReverseMap();

        CreateMap<Employee, EmployeeReadDto>().
        ForMember(dest => dest.PrivellgeName, src => src.MapFrom(src => src.Privillage.PrivellgeName))
     .   ForMember(dest => dest.branchName, src => src.MapFrom(src => src.branch.branchName)).ReverseMap();


          

        CreateMap<EmployeeAddDto, Employee>()
         .ForMember(dest=>dest.branchid,src=>src.MapFrom(src=>src.branchid))
         .ForMember(dest=>dest.privillageid,src=>src.MapFrom(src=>src.Privellge_Id)).ReverseMap();
            
        CreateMap<EmployeeupdateDto, Employee>()
            .ForMember(dest => dest.branchid, src => src.MapFrom(src => src.branchid))
         .ForMember(dest => dest.privillageid, src => src.MapFrom(src => src.Privellge_Id)).ReverseMap();


        CreateMap<GovermentReadDto, Goverment>().ReverseMap();
        CreateMap<GovermentAddDto, Goverment>().ReverseMap();
        CreateMap<GovermentUpdateDto, Goverment>().ReverseMap();

        CreateMap<CityReadDto, City>().ReverseMap();
        CreateMap<CityAddDto, City>().ReverseMap();
        CreateMap<CityUpdateDto, City>().ReverseMap();

        CreateMap<CustomerReadDto, Customer>().ReverseMap();
        CreateMap<CustomerAddDto, Customer>().ReverseMap();
        CreateMap<CustomerUpdateDto, Customer>().ReverseMap();

        CreateMap<ProductReadDtos, Product>().ReverseMap();
        CreateMap<ProductUpdateDtos, Product>().ForMember(dest=>dest.Product_Id,src=>src.MapFrom(src=>src.Product_Id)).ReverseMap();
        CreateMap<AddProductDto,Product>().ReverseMap();
        CreateMap<ProductDeletDtos,Product>().ReverseMap();

        CreateMap<SalesDeletDtos, SalesRepresentative>().ReverseMap();
        CreateMap<SalesReadDtos, SalesRepresentative>().ReverseMap();
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
