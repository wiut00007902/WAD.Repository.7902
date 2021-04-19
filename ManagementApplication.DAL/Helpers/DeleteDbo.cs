using ManagementApplication.DAL.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Helpers
{
    // Class contains methods that delete the data from the database. They are applied
    // according to parameters passsed.
    class DeleteDbo
    {
        // Method for deleting the Task.
        #region Delete Task
        // Mehod is called, when Task object is passed as the first parameter.
        public static async System.Threading.Tasks.Task Delete(DBO.Task task, ManagementApplicationDbContext context)
        {
            // Entity Task is removed.
            context.Tasks.Remove(task);
            // Save all changes asynchronous.
            await context.SaveChangesAsync();
        }
        #endregion
        // Method for deleting the Department.
        #region Delete Department
        // Mehod is called, when Department object is passed as the first parameter.
        public static async System.Threading.Tasks.Task Delete(Department department, ManagementApplicationDbContext context)
        {
            // CascadeDelete constructor for department is called.
            new CascadeDelete(department, context);
            // Entity Department is removed.
            context.Departments.Remove(department);
            // Save all changes asynchronous.
            await context.SaveChangesAsync();
        }
        #endregion
        // Method for deleting the Employee.
        #region Delete Employee
        // Mehod is called, when Employee object is passed as the first parameter.
        public static async System.Threading.Tasks.Task Delete(Employee employee, ManagementApplicationDbContext context)
        {
            // CascadeDelete constructor for employee is called.
            new CascadeDelete(employee, context);
            // Entity Employee is removed.
            context.Employees.Remove(employee);
            // Save all changes asynchronous.
            await context.SaveChangesAsync();
        }
        #endregion
        // Method for deleting the Region.
        #region Delete Region
        // Mehod is called, when Region object is passed as the first parameter.
        public static async System.Threading.Tasks.Task Delete(Region region, ManagementApplicationDbContext context)
        {
            // CascadeDelete constructor for reigon is called.
            new CascadeDelete(region, context);
            // Entity Region is removed.
            context.Regions.Remove(region);
            // Save all changes asynchronous.
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
