using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementApplication.Models
{
    public class Employee
    {
        // ID of the employee
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, insert the first name"), MinLength(2, ErrorMessage = "First name must be at least 2 symbols")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please, insert the last name"), MinLength(2, ErrorMessage = "Last name must be at least 2 symbols")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please, insert the date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please, insert the gender")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Please, insert the passport number")]
        public string PassportNo { get; set; }
        [Required(ErrorMessage = "Please, insert the address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please, insert the phone number"), Phone]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please, insert the email"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please, insert the employee's department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please, insert the employee's position")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Please, insert the employee's salary")]
        public float Salary { get; set; }
        [Required(ErrorMessage = "Please, select the schedule of the work")]
        public Schedule Schedule { get; set; }
        [Required(ErrorMessage = "Please, insert the manager ID")]
        public int ManagerId { get; set; }
        public DateTime EmployedOnDate { get; set; }
        public bool IsManager { get; set; }
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
