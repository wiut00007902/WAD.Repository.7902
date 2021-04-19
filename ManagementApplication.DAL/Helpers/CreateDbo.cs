using ManagementApplication.DAL.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Helpers
{
    // Class contains methods that create the data in the database. They are applied
    // according to parameters passsed.
    class CreateDbo
    {
        // Method for creating the task.
        #region Create Task
        // Mehod is called, when Task object is passed as the first parameter.
        public static async System.Threading.Tasks.Task Create(DBO.Task task, ManagementApplicationDbContext context)
        {
            // CreationDateSet constructor for task is called.
            new CreationDateSet(task);
            // New task is added to Tasks table.
            context.Tasks.Add(task);
            // Save all changes asynchronous.
            await context.SaveChangesAsync();
        }
        #endregion
        // Method for creating the department.
        #region Create Department
        // Mehod is called, when Department object is passed as the first parameter.
        public static async System.Threading.Tasks.Task Create(Department department, ManagementApplicationDbContext context)
        {
            // CreationDateSet constructor for department is called.
            new CreationDateSet(department);
            // New department is added to Departments table.
            context.Departments.Add(department);
            // Save all changes asynchronous.
            await context.SaveChangesAsync();
        }
        #endregion
        // Method for creating the employee.
        #region Create Employee
        // Mehod is called, when Employee object is passed as the first parameter.
        public static async System.Threading.Tasks.Task Create(Employee employee, ManagementApplicationDbContext context)
        {
            // CreationDateSet constructor for employee is called.
            new CreationDateSet(employee);
            // New employee is added to Employees table.
            context.Employees.Add(employee);
            // Save all changes asynchronous.
            await context.SaveChangesAsync();
        }
        #endregion
        // Method for creating the region.
        #region Create Region
        // Mehod is called, when Region object is passed as the first parameter.
        public static async System.Threading.Tasks.Task Create(Region region, ManagementApplicationDbContext context)
        {
            // CreationDateSet constructor for region is called.
            new CreationDateSet(region);
            // New region is added to Regions table.
            context.Regions.Add(region);
            // Save all changes asynchronous.
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
