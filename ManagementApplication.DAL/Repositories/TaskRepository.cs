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
        // Method for creation new task.
        #region Create
        public async System.Threading.Tasks.Task CreateAsync(DBO.Task entity)
        {
            await CreateDbo.Create(entity, _context);
        }
        #endregion
        // Method for deletion the task.
        #region Delete
        public async System.Threading.Tasks.Task DeleteAsync(DBO.Task entity)
        {
            await DeleteDbo.Delete(entity, _context);
        }
        #endregion
        // Method that checks the existence of the task.
        #region Exists
        public bool Exists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
        #endregion
        // Method for retrieving all tasks.
        #region GetAll
        public async Task<List<DBO.Task>> GetAllAsync()
        {
            return await _context.Tasks.Include("Employee").ToListAsync();
        }
        #endregion
        // Method for retrieving the task by id.
        #region GetById
        public async Task<DBO.Task> GetByIdAsync(int id)
        {
            return await _context.Tasks.Include("Employee").SingleOrDefaultAsync(i => i.Id == id);
        }
        #endregion
        // Method for updating the task.
        #region Update
        public async System.Threading.Tasks.Task UpdateAsync(DBO.Task entity)
        {
            await UpdateDbo.Update(entity, _context);
        }
        #endregion
    }
}
