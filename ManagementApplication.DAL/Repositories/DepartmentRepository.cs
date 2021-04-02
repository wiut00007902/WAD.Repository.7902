using ManagementApplication.DAL.DBO;
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
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.Include(d => d.Region).ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _context.Departments
                .Include(d => d.Region)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async System.Threading.Tasks.Task UpdateAsync(Department entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
