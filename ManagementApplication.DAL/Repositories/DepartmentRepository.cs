﻿using ManagementApplication.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Repositories
{
    public class DepartmentRepository : BaseRepository, IRepository<Department>
    {
        public DepartmentRepository(ManagementApplicationDbContext context) : base(context)
        {
        }
        public async System.Threading.Tasks.Task CreateAsync(Department entity)
        {
            entity.CreationDate = DateTime.Now;
            _context.Departments.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(Department entity)
        {
            foreach (var employee in _context.Employees.ToList())
            {
                if (employee.Department != null && employee.Department.Id == entity.Id)
                {
                    foreach(var task in _context.Tasks.ToList())
                    {
                        if(task.Employee != null && task.EmployeeId == employee.Id)
                        {
                            _context.Tasks.Remove(task);
                        }
                    }
                    _context.Employees.Remove(employee);
                }
            }

            _context.Departments.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.Include("Region").ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _context.Departments.Include("Region").SingleOrDefaultAsync(i => i.Id == id);
        }

        public async System.Threading.Tasks.Task UpdateAsync(Department entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
