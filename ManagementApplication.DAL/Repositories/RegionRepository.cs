using ManagementApplication.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Repositories
{
    public class RegionRepository : IRepository<Region>
    {
        private readonly ManagementApplicationDbContext _context;
        public RegionRepository(ManagementApplicationDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task CreateAsync(Region entity)
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
            return _context.Regions.Any(e => e.Id == id);
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Regions
                .ToListAsync();
        }

        public async Task<Region> GetByIdAsync(int id)
        {
            return await _context.Regions
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async System.Threading.Tasks.Task UpdateAsync(Region entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
