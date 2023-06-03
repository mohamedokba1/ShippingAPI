using AutoMapper;
using Shipping.Entities.Models;
using Shipping.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeReadDto , Employee> ().ReverseMap();
            CreateMap<EmployeeAddDto, Employee> ().ReverseMap();
            CreateMap<EmployeeupdateDto, Employee> ().ReverseMap();

            CreateMap<GovermentReadDto, Goverment> ().ReverseMap(); 
            CreateMap<GovermentAddDto, Goverment> ().ReverseMap(); 
            CreateMap<GovermentUpdateDto, Goverment> ().ReverseMap(); 


        }

        

    }
}
