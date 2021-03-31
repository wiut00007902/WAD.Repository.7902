using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementApplication.Models
{
    public class Employee
    {
        [Display(Name = "Employee ID")]
        // ID of the employee
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, insert the first name"), MinLength(2, ErrorMessage = "First name must be at least 2 symbols"), Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please, insert the last name"), MinLength(2, ErrorMessage = "Last name must be at least 2 symbols"), Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please, insert the date of birth"), Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please, insert the gender"), Display(Name = "Gender")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Please, insert the passport number"), Display(Name = "Passport number")]
        public string PassportNo { get; set; }
        [Required(ErrorMessage = "Please, insert the address"), Display(Name = "Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please, insert the phone number"), Phone, Display(Name = "Phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please, insert the email"), EmailAddress, Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please, insert the employee's department"), Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [Required(ErrorMessage = "Please, insert the employee's position"), Display(Name = "Position")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Please, insert the employee's salary"), Display(Name = "Salary in UZS")]
        public float Salary { get; set; }
        [Required(ErrorMessage = "Please, select the schedule of the work"), Display(Name = "Schedule")]
        public Schedule Schedule { get; set; }
        [Display(Name = "Employment date")]
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
