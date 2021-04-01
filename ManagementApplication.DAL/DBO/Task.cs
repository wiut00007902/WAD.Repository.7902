using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementApplication.DAL.DBO
{
    public class Task : IValidatableObject
    {
        [Display(Name = "Task ID")]
        public int Id { get; set; }
        [Display(Name = "Creation date")]
        public DateTime CreationTime { get; set; }
        [Display(Name = "Task name")]
        public string TaskName { get; set; }
        [Required(ErrorMessage = "You have to describe the task"), MinLength(100, ErrorMessage = "Task description is too short. It should be at least 100 symbols."), Display(Name = "Task description")]
       public string TaskDescription { get; set; }
        [Display(Name = "Employee")]
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        [Required(ErrorMessage = "You have to set the task deadline"), Display(Name = "Deadline")]
        public DateTime Deadline { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            if (DateTime.Now > Deadline)
            {
                validationResults.Add(new ValidationResult("Deadline date cannot be earlier than creation date. Please, set proper deadline", new[] { "Deadline" }));
            }
            return validationResults;
        }
    }
}
