﻿using ManagementApplication.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly ManagementApplicationDbContext _context;
        public EmployeeRepository(ManagementApplicationDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task CreateAsync(Employee entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            var region = await _context.Regions.FindAsync(id);
            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.Include(e => e.Department).ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async System.Threading.Tasks.Task UpdateAsync(Employee entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
