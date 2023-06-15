using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using Shipping.Entities.Domain.Identity;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shipping.Repositories.Repos
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public EmployeeRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this._userManager = userManager;
        }
        public async  Task Add(Employee employee)
        {
           await  context.Employees.AddAsync(employee);
        }         

        public async Task Delete(string id)
        {
            var employee = GetByid(id);
             context.Remove(employee);
        }

        public async Task<IEnumerable<Employee>> Getall()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByid(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user as Employee;
        }

        public async Task Savechanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task Update(string id, Employee? employee)
        {

        }
    }
}
