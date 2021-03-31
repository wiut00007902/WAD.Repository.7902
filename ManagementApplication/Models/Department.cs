using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementApplication.Models
{
    public class Department
    {
        [Display(Name = "Department ID")]
        // Id of the department
        public int Id { get; set; }
        // Date of the creation of department. Not required field, as it will be set automaitcally
        [Display(Name = "Creation date")]
        public DateTime CreationDate { get; set; }
        // Data annotaions for DepartmentName string. The field is required and must be at least 5 symbols long
        [Required(ErrorMessage = "Please, insert the department name"), MinLength(5, ErrorMessage = "Please, insert valit and descriptive department name. The minimum length of the department name should be 5 symbols"), Display(Name = "Department name")]
        // Department name
        public string DepartmentName { get; set; }
        // Data annotation that require the user to depict the reqion in which the department operates
        [Required(ErrorMessage = "Please, choose the region where the department is located at"), Display(Name = "Region")]
        // Region ID of the department
        public int? RegionId { get; set; }
        // Data annotations that reuire the user to depict the manager of the department
        public virtual Region Region { get; set; }
    }
}
