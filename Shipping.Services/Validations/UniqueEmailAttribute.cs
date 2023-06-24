using Shipping.Entities;
using Shipping.Entities.Domain.Models;
using Shipping.Services.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Entities.Domain;

public class UniqueEmailAttribute : ValidationAttribute
{
    private readonly ApplicationDbContext context;

   

    public UniqueEmailAttribute(ApplicationDbContext context)
    {
        this.context = context;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        Employee empFromRequest = validationContext.ObjectInstance as Employee;

        string email = value.ToString();

        Employee empFromDb= context.Employees.FirstOrDefault(e => e.User.Email == email);    
        if (empFromDb == null)
        {
            return ValidationResult.Success;
        }
        return new ValidationResult("email already found");
    }
}
