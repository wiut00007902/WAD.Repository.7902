using ManagementApplication.DAL.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Helpers
{
    class CreateDbo
    {
        public static async System.Threading.Tasks.Task Create(DBO.Task task, ManagementApplicationDbContext context)
        {
            new CreationDateSet(task);
            context.Tasks.Add(task);
            await context.SaveChangesAsync();
        }

        public static async System.Threading.Tasks.Task Create(Department department, ManagementApplicationDbContext context)
        {
            new CreationDateSet(department);
            context.Departments.Add(department);
            await context.SaveChangesAsync();
        }

        public static async System.Threading.Tasks.Task Create(Employee employee, ManagementApplicationDbContext context)
        {
            new CreationDateSet(employee);
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
        }

        public static async System.Threading.Tasks.Task Create(Region region, ManagementApplicationDbContext context)
        {
            new CreationDateSet(region);
            context.Regions.Add(region);
            await context.SaveChangesAsync();
        }
    }
}
