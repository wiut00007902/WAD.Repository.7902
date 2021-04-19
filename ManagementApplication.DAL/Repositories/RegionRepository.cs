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
    public class RegionRepository : BaseRepository, IRepository<Region>
    {
        public RegionRepository(ManagementApplicationDbContext context) : base(context)
        {
        }

        public async System.Threading.Tasks.Task CreateAsync(Region entity)
        {
            await CreateDbo.Create(entity, _context);
        }

        public async System.Threading.Tasks.Task DeleteAsync(Region entity)
        {
            new CascadeDelete(entity, _context);

            _context.Regions.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Regions.Any(e => e.Id == id);
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<Region> GetByIdAsync(int id)
        {
            return await _context.Regions.FindAsync(id);
        }

        public async System.Threading.Tasks.Task UpdateAsync(Region entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
