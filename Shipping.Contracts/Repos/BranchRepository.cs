using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repositories.Repos
{
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDbContext context;

        public BranchRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Branch>> GetAllAsync()
        {
            return await context.Branches.ToListAsync();
        }
    }
}

