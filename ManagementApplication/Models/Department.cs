using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementApplication.Models
{
    public class Department
    {

        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        [Required]
        public int? RegionId { get; set; }
        [Required]
        public int? ManagerId { get; set; }
    }
}
