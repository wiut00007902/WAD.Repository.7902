using ManagementApplication.DAL.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Helpers
{
    // Class for casscade deleting of tables. If table has FK, all FK data in all
    // tables will be deleted. Constructors are applied according to the parameters passed.
    public class CascadeDelete
    {
        // Constructor that will be implemented, if Employee object is passed as a first parameter.
        #region Employee's CascadeDelete
        public CascadeDelete(Employee employee, ManagementApplicationDbContext context)
        {
            // Goes through all tasks in Tasks table.
            foreach (var task in context.Tasks.ToList())
            {
                // Task will be removed, if it has Employee and if this Employee's ID
                // equals to ID of the passed employee.
                if ((task.Employee != null) && (task.Employee.Id == employee.Id))
                {
                    context.Tasks.Remove(task);
                }
            }
        }
        #endregion

        // Constructor that will be implemented, if Department object is passed as a first parameter.
        #region Department's CascadeDelete
        public CascadeDelete(Department department, ManagementApplicationDbContext context)
        {
            // Goes through all employees in Employee table.
            foreach (var employee in context.Employees.ToList())
            {
                // Employee will be removed, if it has Department and if this Department's ID
                // equals to ID of the passed department.
                if (employee.Department != null && employee.Department.Id == department.Id)
                {
                    // Afterwards, all tasks will be scanned. If employee has tasks,
                    // they will be deleted.
                    foreach (var task in context.Tasks.ToList())
                    {
                        if (task.Employee != null && task.EmployeeId == employee.Id)
                        {
                            context.Tasks.Remove(task);
                        }
                    }
                    context.Employees.Remove(employee);
                }
            }
        }
        #endregion

        // Constructor that will be implemented, if Region object is passed as a first parameter.
        #region Region's CascadeDelete
        public CascadeDelete(Region region, ManagementApplicationDbContext context)
        {
            // Goes through all departments in Departments table.
            foreach (var department in context.Departments.ToList())
            {
                // Department will be removed, if it has Region and if this Regions's ID
                // equals to ID of the passed region.
                if (department.Region != null && department.Region.Id == region.Id)
                {
                    // Afterwards, all employees will be scanned. If employee has department,
                    // he will be deleted.
                    foreach (var employee in context.Employees.ToList())
                    {
                        if (employee.Department != null && employee.Department.Id == department.Id)
                        {
                            foreach (var task in context.Tasks.ToList())
                            {
                                // Afterwards, all tasks will be scanned. If employee has tasks,
                                // they will be deleted.
                                if (task.Employee != null && task.EmployeeId == employee.Id)
                                {
                                    context.Tasks.Remove(task);
                                }
                            }
                            context.Employees.Remove(employee);
                        }
                    }
                    context.Departments.Remove(department);
                }
            }
        }
        #endregion
    }
}
