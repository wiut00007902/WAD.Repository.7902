using ManagementApplication.DAL.DBO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApplication.Models
{
    public class EmployeeViewModel : Employee
    {
        public SelectList Departments { get; set; }
    }
}
