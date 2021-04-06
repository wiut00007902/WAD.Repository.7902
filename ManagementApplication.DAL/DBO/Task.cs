using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementApplication.DAL.DBO
{
    public class Task : IValidatableObject
    {
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }

        [Required]
        public string TaskName { get; set; }

        [Required, MinLength(10)]
       public string TaskDescription { get; set; }

        [Required]
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        [Required]
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
