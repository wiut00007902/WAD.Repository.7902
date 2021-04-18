using ManagementApplication.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Repositories
{
    public class EmployeeRepository : BaseRepository, IRepository<Employee>
    {
        public EmployeeRepository(ManagementApplicationDbContext context) : base(context)
        {
        }

        public async System.Threading.Tasks.Task CreateAsync(Employee entity)
        {
            entity.EmploymentDate = DateTime.Now;
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(Employee entity)
        {
            foreach (var task in _context.Tasks.ToList())
            {
                if(task.Employee != null && task.Employee.Id == entity.Id)
                {
                    _context.Tasks.Remove(task);
                }
            }

            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.Include("Department").ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.Include("Department").SingleOrDefaultAsync(i => i.Id == id);
        }

        public async System.Threading.Tasks.Task UpdateAsync(Employee entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
