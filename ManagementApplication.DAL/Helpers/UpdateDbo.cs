using ManagementApplication.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Helpers
{
    class UpdateDbo
    {
        public static async System.Threading.Tasks.Task Update(DBO.Task task, ManagementApplicationDbContext context)
        {
            context.Entry(task).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public static async System.Threading.Tasks.Task Update(Department department, ManagementApplicationDbContext context)
        {
            context.Entry(department).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public static async System.Threading.Tasks.Task Update(Employee employee, ManagementApplicationDbContext context)
        {
            context.Entry(employee).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public static async System.Threading.Tasks.Task Update(Region region, ManagementApplicationDbContext context)
        {
            context.Entry(region).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
