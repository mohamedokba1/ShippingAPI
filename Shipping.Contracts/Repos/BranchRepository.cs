﻿using Shipping.Entities.Domain.Models;
using Shipping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class BranchRepository:IBranchRepository
{
    private readonly ApplicationDbContext _context;
    public BranchRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Branch>> GetAllAsync()
    {
        return await _context.Set<Branch>().ToListAsync();
    }

    public async Task<Branch> GetByIdAsync(int id)
    {
        return await _context.Set<Branch>().FindAsync(id);
    }

    public async Task AddAsync(Branch entity)
    {
        await _context.Set<Branch>().AddAsync(entity);
    }

    public async Task UpdateAsync(Branch entity)
    {
        _context.Set<Branch>().Update(entity);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Branch entity)
    {
        _context.Set<Branch>().Remove(entity);
        await Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

}
