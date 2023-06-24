using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shipping.Entities.Domain.Identity;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
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
            IEmployeeRepository employeeRepository ,
            IMapper mapper,
            UserManager<ApplicationUser> userManager
            )
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public async Task<List<ValidationResult>?> Add(EmployeeAddDto employeeDto)
        {
            List<ValidationResult>? validationResult = ValidateModel.ModelValidation(employeeDto);
            if (validationResult?.Count == 0)
            {
                ApplicationUser? checkuserEmail = await userManager.FindByEmailAsync(employeeDto.Email);
                if (checkuserEmail is null)
                {
                    ApplicationUser? checkuserName = await userManager.FindByNameAsync(employeeDto.UserName);
                    if (checkuserName is null)
                    {

                   

                    ApplicationUser user = mapper.Map<ApplicationUser>(employeeDto);
                    IdentityResult result = await userManager.CreateAsync(user);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ValidationResult err = new ValidationResult(error.Description);
                            validationResult.Add(err);
                        }
                        return validationResult;
                    }
                    await userManager.AddToRoleAsync(user, "employee");
                    await userManager.UpdateAsync(user);
                    ApplicationUser? addedUser = await userManager.FindByEmailAsync(employeeDto.Email);
                    employeeDto.User = addedUser;

                }
                else
                {
                    validationResult.Add(new ValidationResult("usre name is already exist"));
                    return validationResult;

                }
            }
            else
            {
                validationResult.Add(new ValidationResult("Email is already exist"));
                return validationResult;
            }

            await employeeRepository.Add(mapper.Map<EmployeeAddDto, Employee>(employeeDto));
            return validationResult;
        }
            else { return validationResult; }

       }




        //    var user = new ApplicationUser
        //    {
        //        UserName = employeeDto.UserName,
        //        Email = employeeDto.Email,
        //        PhoneNumber = employeeDto.PhoneNumber,
        //        PasswordHash = employeeDto.Password
        //    };

        //    var employee = new Employee
        //    {
        //        Name = employeeDto.Name,
        //        Password = employeeDto.Password,
        //        IsActive = employeeDto.IsActive,
        //        branchid = employeeDto.branchid,
        //        User = user
        //    };

        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.NameIdentifier,user.Id) ,
        //        new Claim(ClaimTypes.Name ,user.UserName) ,
        //        new Claim(ClaimTypes.Role , "employee")
        //    };

        //    await userManager.AddClaimsAsync(user, claims);

        //    await userManager.CreateAsync(user, employeeDto.Password);

        //    await employeeRepository.Add(employee);
        //    await employeeRepository.Savechanges();



        //}

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
