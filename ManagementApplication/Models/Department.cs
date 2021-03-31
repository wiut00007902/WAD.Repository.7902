using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApplication.Models
{
    public class Department
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string DepartmentName { get; set; }
        public int? RegionId { get; set; }
        public int? ManagerId { get; set; }
    }
}
