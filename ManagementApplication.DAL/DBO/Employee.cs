using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementApplication.DAL.DBO
{
    public class Employee
    {
        public int Id { get; set; }

        [Required, MinLength(2)]
        public string FirstName { get; set; }

        [Required, MinLength(2)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string PassportNo { get; set; }

        [Required]
        public string Address { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public float Salary { get; set; }

        [Required]
        public Schedule Schedule { get; set; }

        public DateTime EmploymentDate { get; set; }
    }
    public enum Schedule
    {
        Fulltime,
        Parttime,
        Fixed,
        Flexible,
        Roating
    }
    public enum Gender
    {
        Male,
        Female
    }
}
