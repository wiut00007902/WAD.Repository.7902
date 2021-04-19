using ManagementApplication.DAL.DBO;
using ManagementApplication.DAL.Helpers;
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
            await CreateDbo.Create(entity, _context);
        }

        public async System.Threading.Tasks.Task DeleteAsync(Employee entity)
        {
            await DeleteDbo.Delete(entity, _context);
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
            await UpdateDbo.Update(entity, _context);
        }
    }
}
