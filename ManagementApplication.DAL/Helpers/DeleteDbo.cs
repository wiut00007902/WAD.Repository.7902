using ManagementApplication.DAL.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Helpers
{
    class DeleteDbo
    {
        public static async System.Threading.Tasks.Task Delete(DBO.Task task, ManagementApplicationDbContext context)
        {
            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
        }

        public static async System.Threading.Tasks.Task Delete(Department department, ManagementApplicationDbContext context)
        {
            new CascadeDelete(department, context);
            context.Departments.Remove(department);
            await context.SaveChangesAsync();
        }

        public static async System.Threading.Tasks.Task Delete(Employee employee, ManagementApplicationDbContext context)
        {
            new CascadeDelete(employee, context);
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
        }

        public static async System.Threading.Tasks.Task Delete(Region region, ManagementApplicationDbContext context)
        {
            new CascadeDelete(region, context);
            context.Regions.Remove(region);
            await context.SaveChangesAsync();
        }
    }
}
