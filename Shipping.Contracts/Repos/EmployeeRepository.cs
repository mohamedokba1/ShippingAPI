using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using Shipping.Entities.Models;
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

        public EmployeeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async  Task Add(Employee employee)
        {
           await  context.Employees.AddAsync(employee);
        }         

        public async Task Delete(Guid id)
        {
            var employee = GetByid(id);
             context.Remove(employee);
        }

        public async Task<IEnumerable<Employee>> Getall()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByid(Guid id)
        {
            return await context.Employees.FirstOrDefaultAsync(e => e.Employee_Id == id);
        }

        public async Task Savechanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Employee? employee)
        {

        }
    }
}
