using ManagementApplication.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Helpers
{
    // Class contains methods that update the data in the database. They are applied
    // according to parameters passsed.
    class UpdateDbo
    {
        // Method for updating the Task.
        #region Update Task
        // Mehod is called, when Task object is passed as the first parameter.
        public static async System.Threading.Tasks.Task Update(DBO.Task task, ManagementApplicationDbContext context)
        {
            // Entity's state is set to 'Modified'.
            context.Entry(task).State = EntityState.Modified;
            // Save all changes asynchronous.
            await context.SaveChangesAsync();
        }
        #endregion
        // Method for updating the Department.
        #region Update Department
        // Mehod is called, when Department object is passed as the first parameter.
        public static async System.Threading.Tasks.Task Update(Department department, ManagementApplicationDbContext context)
        {
            // Entity's state is set to 'Modified'.
            context.Entry(department).State = EntityState.Modified;
            // Save all changes asynchronous.
            await context.SaveChangesAsync();
        }
        #endregion
        // Method for updating the Employee.
        #region Update Employee
        // Mehod is called, when Employee object is passed as the first parameter.
        public static async System.Threading.Tasks.Task Update(Employee employee, ManagementApplicationDbContext context)
        {
            // Entity's state is set to 'Modified'.
            context.Entry(employee).State = EntityState.Modified;
            // Save all changes asynchronous.
            await context.SaveChangesAsync();
        }
        #endregion
        // Method for updating the Region.
        #region Update Region
        // Mehod is called, when Region object is passed as the first parameter.
        public static async System.Threading.Tasks.Task Update(Region region, ManagementApplicationDbContext context)
        {
            // Entity's state is set to 'Modified'.
            context.Entry(region).State = EntityState.Modified;
            // Save all changes asynchronous.
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
