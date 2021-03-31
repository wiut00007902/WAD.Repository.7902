using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementApplication.Models
{
    public class Task : IValidatableObject
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        [Required(ErrorMessage = "You have to describe the task"), MinLength(100, ErrorMessage = "Task description is too short. It should be at least 100 symbols.")]
        public string TaskDescription { get; set; }
        [Required(ErrorMessage = "You have to set the task deadline")]
        public DateTime Daedline { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            if(CreationTime < Daedline)
            {
                validationResults.Add(new ValidationResult("Deadline date cannot be earlier than creation date. Please, set proper deadline", new[] { "Daedline" }));
            }
            return validationResults;
        }
    }
}
