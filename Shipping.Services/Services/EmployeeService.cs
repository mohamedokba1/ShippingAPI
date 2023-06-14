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

        }

        public async Task Delete(long id)
        {
             await employeeRepository.Delete(id);
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
            Employee empfromDb =await employeeRepository.GetByid(id);
            if(empfromDb != null)
            {
                empfromDb = mapper.Map<Employee>(empfromDb);
              await   employeeRepository.Update(id, empfromDb);

            }
        }
    }
}
