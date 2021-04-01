using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementApplication.DAL.DBO
{
    public class Department
    {
        [Display(Name = "Department ID")]
        public int Id { get; set; }
        [Display(Name = "Creation date")]
        public DateTime CreationDate { get; set; }
        [Required(ErrorMessage = "Please, insert the department name"), MinLength(5, ErrorMessage = "Please, insert valit and descriptive department name. The minimum length of the department name should be 5 symbols"), Display(Name = "Department name")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Please, choose the region where the department is located at"), Display(Name = "Region")]
        public int? RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
}
