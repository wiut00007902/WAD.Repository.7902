using ManagementApplication.DAL.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Helpers
{
    class CreationDateSet
    {
        public CreationDateSet(Employee employee)
        {
            employee.EmploymentDate = DateTime.Now;
        }
        
        public CreationDateSet(Department department)
        {
            department.CreationDate = DateTime.Now;
        }

        public CreationDateSet(Region region)
        {
            region.CreationDate = DateTime.Now;
        }

        public CreationDateSet(DBO.Task task)
        {
            task.CreationTime = DateTime.Now;
        }
    }
}
