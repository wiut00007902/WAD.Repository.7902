using ManagementApplication.DAL.Helpers;
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
        #region TaskRepository constructor
        public TaskRepository(ManagementApplicationDbContext context) : base(context)
        {
        }
        #endregion
        // Method for creation the new task.
        #region Create
        public async System.Threading.Tasks.Task CreateAsync(DBO.Task entity)
        {
            // Calling method Create from CreateDbo class. Passing the required values.
            // Entity value will choose proper method from all Create methods in CreateDbo class.
            await CreateDbo.Create(entity, _context);
        }
        #endregion
        // Method for deletion the task.
        #region Delete
        public async System.Threading.Tasks.Task DeleteAsync(DBO.Task entity)
        {
            // Calling method Delete from DeleteDbo class. Passing the required values.
            // Entity value will choose proper method from all Delete methods in DeleteDbo class.
            await DeleteDbo.Delete(entity, _context);
        }
        #endregion
        // Method that checks the existence of the task.
        #region Exists
        public bool Exists(int id)
        {
            // Method scans through all tasks and returns 'true'
            // if there is a match with passed parameter 'id'.
            // Otherwise, it returns 'false'.
            return _context.Tasks.Any(e => e.Id == id);
        }
        #endregion
        // Method for retrieving all tasks.
        #region GetAll
        public async Task<List<DBO.Task>> GetAllAsync()
        {
            // Method gets all data from Task table and converts it to
            // list asynchronous, including data about Employee.
            return await _context.Tasks.Include("Employee").ToListAsync();
        }
        #endregion
        // Method for retrieving the task by id.
        #region GetById
        public async Task<DBO.Task> GetByIdAsync(int id)
        {
            // Method searches task by ID passed in parameters. Then it returns all
            // information about found entity, including information about Employee.
            return await _context.Tasks.Include("Employee").SingleOrDefaultAsync(i => i.Id == id);
        }
        #endregion
        // Method for updating the task.
        #region Update
        public async System.Threading.Tasks.Task UpdateAsync(DBO.Task entity)
        {
            // Calling method Update from UpdateDbo class. Passing the required values.
            // Entity value will choose proper method from all Create methods in CreateDbo class.
            await UpdateDbo.Update(entity, _context);
        }
        #endregion
    }
}
