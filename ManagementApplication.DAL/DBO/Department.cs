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

        [Required, MinLength(5)]
        public string DepartmentName { get; set; }

        [Required]
        public int? RegionId { get; set; }

        public virtual Region Region { get; set; }
    }
}
