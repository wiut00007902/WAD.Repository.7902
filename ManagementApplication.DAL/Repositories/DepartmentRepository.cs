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
        #region DepartmentRepository constructor
        public DepartmentRepository(ManagementApplicationDbContext context) : base(context)
        {
        }
        #endregion
        // Method for creation the new department.
        #region Create
        public async System.Threading.Tasks.Task CreateAsync(Department entity)
        {
            // Calling method Create from CreateDbo class. Passing the required values.
            // Entity value will choose proper method from all Create methods in CreateDbo class.
            await CreateDbo.Create(entity, _context);
        }
        #endregion
        // Method for deletion the department.
        #region Delete
        public async System.Threading.Tasks.Task DeleteAsync(Department entity)
        {
            // Calling method Delete from DeleteDbo class. Passing the required values.
            // Entity value will choose proper method from all Delete methods in DeleteDbo class.
            await DeleteDbo.Delete(entity, _context);
        }
        #endregion
        // Method that checks the existence of the department.
        #region Exists
        public bool Exists(int id)
        {
            // Method scans through all departments and returns 'true'
            // if there is a match with passed parameter 'id'.
            // Otherwise, it returns 'false'.
            return _context.Departments.Any(e => e.Id == id);
        }
        #endregion
        // Method for retrieving all departments.
        #region GetAll
        public async Task<List<Department>> GetAllAsync()
        {
            // Method gets all data from Departments table and converts it to
            // list asynchronous, including data about Region.
            return await _context.Departments.Include("Region").ToListAsync();
        }
        #endregion
        // Method for retrieving the department by id.
        #region GetById
        public async Task<Department> GetByIdAsync(int id)
        {
            // Method searches department by ID passed in parameters. Then it returns all
            // information about found entity, including information about Region.
            return await _context.Departments.Include("Region").SingleOrDefaultAsync(i => i.Id == id);
        }
        #endregion
        // Method for updating the department.
        #region Update
        public async System.Threading.Tasks.Task UpdateAsync(Department entity)
        {
            // Calling method Update from UpdateDbo class. Passing the required values.
            // Entity value will choose proper method from all Create methods in CreateDbo class.
            await UpdateDbo.Update(entity, _context);
        }
        #endregion
    }
}
