using ManagementApplication.DAL.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Helpers
{
    public class CascadeDelete
    {
        public CascadeDelete(Employee employee, ManagementApplicationDbContext context)
        {
            foreach (var task in context.Tasks.ToList())
            {
                if ((task.Employee != null) && (task.Employee.Id == employee.Id))
                {
                    context.Tasks.Remove(task);
                }
            }
        }

        public CascadeDelete(Department department, ManagementApplicationDbContext context)
        {
            foreach (var employee in context.Employees.ToList())
            {
                if (employee.Department != null && employee.Department.Id == department.Id)
                {
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
        
        public CascadeDelete(Region region, ManagementApplicationDbContext context)
        {
            foreach (var department in context.Departments.ToList())
            {
                if (department.Region != null && department.Region.Id == region.Id)
                {
                    foreach (var employee in context.Employees.ToList())
                    {
                        if (employee.Department != null && employee.Department.Id == department.Id)
                        {
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
                    context.Departments.Remove(department);
                }
            }
        }

        public CascadeDelete(DBO.Task task, ManagementApplicationDbContext context)
        {

        }
    }
}
