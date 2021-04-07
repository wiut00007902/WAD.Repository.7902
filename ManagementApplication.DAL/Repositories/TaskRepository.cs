using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Repositories
{
    public class TaskRepository : BaseRepository, IRepository<DBO.Task>
    {
        public TaskRepository(ManagementApplicationDbContext context) : base(context)
        {
        }

        public async System.Threading.Tasks.Task CreateAsync(DBO.Task entity)
        {
            _context.Tasks.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(DBO.Task entity)
        {
            _context.Tasks.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }

        public async Task<List<DBO.Task>> GetAllAsync()
        {
            return await _context.Tasks.Include("Employee").ToListAsync();
        }

        public async Task<DBO.Task> GetByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async System.Threading.Tasks.Task UpdateAsync(DBO.Task entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
