using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementApplication.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string PassportNo { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string Position { get; set; }
        public float Salary { get; set; }
        public Schedule Schedule { get; set; }
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
