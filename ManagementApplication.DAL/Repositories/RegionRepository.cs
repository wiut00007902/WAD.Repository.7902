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
        #region RegionRepository constructor
        public RegionRepository(ManagementApplicationDbContext context) : base(context)
        {
        }
        #endregion
        // Method for creation the new region.
        #region Create
        public async System.Threading.Tasks.Task CreateAsync(Region entity)
        {
            // Calling method Create from CreateDbo class. Passing the required values.
            // Entity value will choose proper method from all Create methods in CreateDbo class.
            await CreateDbo.Create(entity, _context);
        }
        #endregion
        // Method for deletion the region.
        #region Delete
        public async System.Threading.Tasks.Task DeleteAsync(Region entity)
        {
            // Calling method Delete from DeleteDbo class. Passing the required values.
            // Entity value will choose proper method from all Delete methods in DeleteDbo class.
            await DeleteDbo.Delete(entity, _context);
        }
        #endregion
        // Method that checks the existence of the region.
        #region Exists
        public bool Exists(int id)
        {
            // Method scans through all regions and returns 'true'
            // if there is a match with passed parameter 'id'.
            // Otherwise, it returns 'false'.
            return _context.Regions.Any(e => e.Id == id);
        }
        #endregion
        // Method for retrieving all regions.
        #region GetAll
        public async Task<List<Region>> GetAllAsync()
        {
            // Method gets all data from Task table and converts it to
            // list asynchronous.
            return await _context.Regions.ToListAsync();
        }
        #endregion
        // Method for retrieving the region by id.
        #region GetById
        public async Task<Region> GetByIdAsync(int id)
        {
            // Method searches region by ID passed in parameters. Then it returns all
            // information about found entity.
            return await _context.Regions.FindAsync(id);
        }
        #endregion
        // Method for updating the region.
        #region Update
        public async System.Threading.Tasks.Task UpdateAsync(Region entity)
        {
            // Calling method Update from UpdateDbo class. Passing the required values.
            // Entity value will choose proper method from all Create methods in CreateDbo class.
            await UpdateDbo.Update(entity, _context);
        }
        #endregion
    }
}
