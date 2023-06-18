using AutoMapper;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;
        public readonly Employee emp; 

        public EmployeeService(IEmployeeRepository employeeRepository , IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }
        public async Task Add(EmployeeAddDto employeeDto)
        {
            Employee e =   mapper.Map<Employee>(employeeDto);
            await employeeRepository.Add(e);
           await employeeRepository.Savechanges();

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
