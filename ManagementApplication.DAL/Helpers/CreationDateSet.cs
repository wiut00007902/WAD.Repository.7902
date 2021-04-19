using ManagementApplication.DAL.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Helpers
{
    // Class for autosetting CreationDate value for the specific entity.
    // Constructors are applied according to the parameters passed.
    class CreationDateSet
    {
        // Constructor sets employment date of employee.
        #region CreationDateSet Employee
        // Constructor that will be implemented, if Employee object is passed as a parameter.
        public CreationDateSet(Employee employee)
        {
            // Initialize employee's employment date to current date.
            employee.EmploymentDate = DateTime.Now;
        }
        #endregion
        // Constructor sets creation date of department.
        #region CreationDateSet Department
        // Constructor that will be implemented, if Department object is passed as a parameter.
        public CreationDateSet(Department department)
        {
            // Initialize department's creation date to current date.
            department.CreationDate = DateTime.Now;
        }
        #endregion
        // Constructor sets creation date of region.
        #region CreationDateSet Region
        public CreationDateSet(Region region)
        {
            // Initialize regions's creation date to current date.
            region.CreationDate = DateTime.Now;
        }
        #endregion
        // Constructor sets creation date of task.
        #region CreationDateSet Task
        // Constructor that will be implemented, if Region object is passed as a parameter.
        public CreationDateSet(DBO.Task task)
        {
            // Initialize task's creation date to current date.
            task.CreationTime = DateTime.Now;
        }
        #endregion
    }
}
