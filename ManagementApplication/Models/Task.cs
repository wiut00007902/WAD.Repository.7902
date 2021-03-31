using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementApplication.Models
{
    // The class Task implements interface IValidatableObject for making a proper validation for Deadline and CreationTime
    public class Task : IValidatableObject
    {
        [Display(Name = "Task ID")]
        // Id of the Task
        public int Id { get; set; }
        [Display(Name = "Creation date")]
        // Date of the creation of the task. Not required field, as it will be set automaitcally
        public DateTime CreationTime { get; set; }
        [Display(Name = "Task name")]
        public string TaskName { get; set; }
        // Data annotations for TaskDeskription string, which requires the field had at least 100 symbols (MinLength). If the field is empty, it requires the user to fill it (Required)
        [Required(ErrorMessage = "You have to describe the task"), MinLength(100, ErrorMessage = "Task description is too short. It should be at least 100 symbols."), Display(Name = "Task description")]
        // Description of the task
        public string TaskDescription { get; set; }
        [Display(Name = "Employee")]
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        // Data annotations for Deadline. The deadline must be set (Required)
        [Required(ErrorMessage = "You have to set the task deadline"), Display(Name = "Deadline")]
        // Deadline of the task
        public DateTime Deadline { get; set; }
        // Implementation of IValidatableObject interface member
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Creationg the list validation result. All errors will be kept in this list and will be shown if they occur
            List<ValidationResult> validationResults = new List<ValidationResult>();
            // Comparing creation date and deadline. The second one shouldn't be earlier than the first one
            if (DateTime.Now > Deadline)
            {
                // Adding validation result to the validatonResults list with error message. The deadline section will be marked if error occures
                validationResults.Add(new ValidationResult("Deadline date cannot be earlier than creation date. Please, set proper deadline", new[] { "Deadline" }));
            }
            // Passing back all the results of the validation
            return validationResults;
        }
    }
}
