using ManagementApplication.DAL.DBO;
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
            entity.CreationDate = DateTime.Now;
            _context.Regions.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(Region entity)
        {
            foreach (var department in _context.Departments.ToList())
            {
                if (department.Region != null && department.Region.Id == entity.Id)
                {
                    foreach (var employee in _context.Employees.ToList())
                    {
                        if (employee.Department != null && employee.Department.Id == department.Id)
                        {
                            foreach (var task in _context.Tasks.ToList())
                            {
                                if (task.Employee != null && task.EmployeeId == employee.Id)
                                {
                                    _context.Tasks.Remove(task);
                                }
                            }
                            _context.Employees.Remove(employee);
                        }
                    }
                    _context.Departments.Remove(department);
                }
            }

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
