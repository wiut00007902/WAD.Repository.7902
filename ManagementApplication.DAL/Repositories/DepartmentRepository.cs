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
    public class DepartmentRepository : BaseRepository, IRepository<Department>
    {
        public DepartmentRepository(ManagementApplicationDbContext context) : base(context)
        {
        }
        public async System.Threading.Tasks.Task CreateAsync(Department entity)
        {
            await CreateDbo.Create(entity, _context);
        }

        public async System.Threading.Tasks.Task DeleteAsync(Department entity)
        {
            await DeleteDbo.Delete(entity, _context);
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
