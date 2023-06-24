using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shipping.Entities.Domain.Identity;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using Shipping.Repositories.Repos;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using Shipping.Services.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        public readonly Employee emp;

        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IMapper mapper,
            UserManager<ApplicationUser> userManager
            )
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public async Task Add(EmployeeAddDto employeeDto)
        {




        }






    public async Task Delete(long id)
        {
            Employee employeeFromDb = await employeeRepository.GetByid(id);
            if(employeeFromDb != null)
            {
                employeeFromDb.IsActive = false;

                await employeeRepository.Savechanges();
            }
            else
            {
                throw new Exception("this employee not found");
            }
        }

        public async Task<IEnumerable<EmployeeReadDto>> Getall()
        {
            var employeesfromDb= await employeeRepository.Getall();
            return mapper.Map<IEnumerable<EmployeeReadDto>>(employeesfromDb);
        }

        public async Task<EmployeeReadDto> GetByid(long id)
        {
            var employeefromDb = await employeeRepository.GetByid(id);

            if (employeefromDb == null)
            {
                return null;
            }
            return mapper.Map<EmployeeReadDto>(employeefromDb);
        }

        public async Task Savechanges()
        {
            await employeeRepository.Savechanges();
        }

        public async Task Update(long id, EmployeeupdateDto employeeDto)
        {
            Employee empFromDb =await employeeRepository.GetByid(id);
            if(empFromDb != null)
            {
                mapper.Map(employeeDto, empFromDb);

                await employeeRepository.Savechanges(); 

            }
            else
            {
                throw new Exception("this employee is not found");
            }
        }
    }
}
