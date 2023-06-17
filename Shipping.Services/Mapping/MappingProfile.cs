using AutoMapper;
using Shipping.Entities.Domain.Models;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.ProductDtos;
using Shipping.Services.Dtos.SalesDtos;
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

        CreateMap<GovermentReadDto, Employee>().ReverseMap();
        CreateMap<EmployeeAddDto, Employee>().ReverseMap();
        CreateMap<EmployeeupdateDto, Employee>().ReverseMap();

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

        CreateMap<ProductReadDtos, Product>().ReverseMap();
        CreateMap<ProductUpdateDtos, Product>().ForMember(dest=>dest.Product_Id,src=>src.MapFrom(src=>src.Product_Id)).ReverseMap();
        CreateMap<AddProductDto,Product>().ReverseMap();
        CreateMap<ProductDeletDtos,Product>().ReverseMap();

        CreateMap<SalesDeletDtos, SalesRepresentative>().ReverseMap();
        CreateMap<SalesReadDtos, SalesRepresentative>().ReverseMap();
        CreateMap<AddSalesDto, SalesRepresentative>().ReverseMap();

        CreateMap<OrderResponseDto, Order>().ReverseMap();
        CreateMap<OrderReadDto, Order>().ReverseMap();
        CreateMap<OrderAddDto, Order>().ReverseMap();
        CreateMap<OrderUpdateDto, Order>().ReverseMap();

       
    }
}
