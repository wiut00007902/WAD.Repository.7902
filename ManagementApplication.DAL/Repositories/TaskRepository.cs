using ManagementApplication.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Repositories
{
    public class TaskRepository : IRepository<DBO.Task>
    {
        private readonly ManagementApplicationDbContext _context;
        public TaskRepository(ManagementApplicationDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task CreateAsync(DBO.Task entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }

        public async Task<List<DBO.Task>> GetAllAsync()
        {
            return await _context.Tasks.Include(t => t.Employee)
                .ToListAsync();
        }

        public async Task<DBO.Task> GetByIdAsync(int id)
        {
            return await _context.Tasks
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async System.Threading.Tasks.Task UpdateAsync(DBO.Task entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
