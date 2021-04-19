using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementApplication.DAL.DBO
{
    public class Department
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string DepartmentName { get; set; }
        public int? RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
}
