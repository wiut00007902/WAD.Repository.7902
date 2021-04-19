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
    public class EmployeeRepository : BaseRepository, IRepository<Employee>
    {
        #region EmployeeRepository constructor
        public EmployeeRepository(ManagementApplicationDbContext context) : base(context)
        {
        }
        #endregion
        // Method for creation the new employee.
        #region Create
        public async System.Threading.Tasks.Task CreateAsync(Employee entity)
        {
            // Calling method Create from CreateDbo class. Passing the required values.
            // Entity value will choose proper method from all Create methods in CreateDbo class.
            await CreateDbo.Create(entity, _context);
        }
        #endregion
        // Method for deletion the employee.
        #region Delete
        public async System.Threading.Tasks.Task DeleteAsync(Employee entity)
        {
            // Calling method Delete from DeleteDbo class. Passing the required values.
            // Entity value will choose proper method from all Delete methods in DeleteDbo class.
            await DeleteDbo.Delete(entity, _context);
        }
        #endregion
        // Method that checks the existence of the employee.
        #region Exists
        public bool Exists(int id)
        {
            // Method scans through all employees and returns 'true'
            // if there is a match with passed parameter 'id'.
            // Otherwise, it returns 'false'.
            return _context.Employees.Any(e => e.Id == id);
        }
        #endregion
        // Method for retrieving all employees.
        #region GetAll
        public async Task<List<Employee>> GetAllAsync()
        {
            // Method gets all data from Employees table and converts it to
            // list asynchronous, including data about Department.
            return await _context.Employees.Include("Department").ToListAsync();
        }
        #endregion
        // Method for retrieving the employee by id.
        #region GetById
        public async Task<Employee> GetByIdAsync(int id)
        {
            // Method searches employee by ID passed in parameters. Then it returns all
            // information about found entity, including information about Department.
            return await _context.Employees.Include("Department").SingleOrDefaultAsync(i => i.Id == id);
        }
        #endregion
        // Method for updating the employee.
        #region Update
        public async System.Threading.Tasks.Task UpdateAsync(Employee entity)
        {
            // Calling method Update from UpdateDbo class. Passing the required values.
            // Entity value will choose proper method from all Create methods in CreateDbo class.
            await UpdateDbo.Update(entity, _context);
        }
        #endregion
    }
}
