using ManagementApplication.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Models
{
    // Extension for ModelBuilder class.
    public static class ModelBuilderExtensions
    {
        // Method seeds the database with values specified bellow.
        #region Seed
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>().HasData(
                    new Region
                    {
                        Id = 1,
                        RegionName = "Uzbekistan",
                        CreationDate = DateTime.Parse("2019-01-01", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)
                    },
                    new Region
                    {
                        Id = 2,
                        RegionName = "USA",
                        CreationDate = DateTime.Parse("2019-01-01", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)
                    }
                );
            modelBuilder.Entity<Department>().HasData(
                    new Department
                    {
                        Id = 1,
                        CreationDate = new DateTime(1990, 6, 25),
                        DepartmentName = "Accounting department",
                        RegionId = 1
                    },
                    new Department
                    {
                        Id = 2,
                        CreationDate = new DateTime(1990, 6, 25),
                        DepartmentName = "IT department",
                        RegionId = 1
                    },
                    new Department
                    {
                        Id = 3,
                        CreationDate = new DateTime(1990, 6, 25),
                        DepartmentName = "Production department",
                        RegionId = 1
                    },
                    new Department
                    {
                        Id = 4,
                        CreationDate = new DateTime(1990, 6, 25),
                        DepartmentName = "Research and Development department",
                        RegionId = 1
                    },
                    new Department
                    {
                        Id = 5,
                        CreationDate = new DateTime(1995, 3, 14),
                        DepartmentName = "Architecture department",
                        RegionId = 2
                    },
                    new Department
                    {
                        Id = 6,
                        CreationDate = new DateTime(1995, 3, 14),
                        DepartmentName = "East Asian Studies department",
                        RegionId = 2
                    },
                    new Department
                    {
                        Id = 7,
                        CreationDate = new DateTime(1995, 3, 14),
                        DepartmentName = "Middle Eastern Studies department",
                        RegionId = 2
                    },
                    new Department
                    {
                        Id = 8,
                        CreationDate = new DateTime(1995, 3, 14),
                        DepartmentName = "French language department",
                        RegionId = 2
                    }
                );
            modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    {
                        Id = 1,
                        FirstName = "John",
                        LastName = "Smith",
                        DateOfBirth = new DateTime(1960, 7, 25),
                        Gender = Gender.Male,
                        PassportNo = "AB7564737",
                        Address = "Little Ring Avn, 13",
                        Phone = "+1-435-545-65-76",
                        Email = "john.smith@mail.ru",
                        DepartmentId = 1,
                        Position = "Manager",
                        Salary = 12000,
                        Schedule = Schedule.Fulltime,
                        EmploymentDate = new DateTime(2020, 12, 3)
                    },
                    new Employee
                    {
                        Id = 2,
                        FirstName = "Phillip",
                        LastName = "Walsh",
                        DateOfBirth = new DateTime(1967, 3, 21),
                        Gender = Gender.Male,
                        PassportNo = "AB5675434",
                        Address = "Amir-Temur street, 24",
                        Phone = "+998-93-647-75-63",
                        Email = "phillip.walsh@mail.ru",
                        DepartmentId = 2,
                        Position = "Software engineer",
                        Salary = 7000,
                        Schedule = Schedule.Parttime,
                        EmploymentDate = new DateTime(2007, 4, 5)
                    },
                    new Employee
                    {
                        Id = 3,
                        FirstName = "Dora",
                        LastName = "Williamson",
                        DateOfBirth = new DateTime(1983, 10, 11),
                        Gender = Gender.Female,
                        PassportNo = "AA7587492",
                        Address = "Alisher Navoiy street, 46",
                        Phone = "+998-97-657-47-86",
                        Email = "dora.williamson@mail.ru",
                        DepartmentId = 3,
                        Position = "Product designer",
                        Salary = 8000,
                        Schedule = Schedule.Roating,
                        EmploymentDate = new DateTime(2020, 10, 3)
                    },
                    new Employee
                    {
                        Id = 4,
                        FirstName = "Nadeem",
                        LastName = "Liu",
                        DateOfBirth = new DateTime(1973, 4, 12),
                        Gender = Gender.Female,
                        PassportNo = "AA8597573",
                        Address = "Mirabad street, 34",
                        Phone = "+998-90-754-98-12",
                        Email = "nadeem.liu@mail.ru",
                        DepartmentId = 4,
                        Position = "Researcher",
                        Salary = 7500,
                        Schedule = Schedule.Flexible,
                        EmploymentDate = new DateTime(2012, 3, 7)
                    }
                );
            modelBuilder.Entity<DBO.Task>().HasData(
                    new DBO.Task
                    {
                        Id = 1,
                        CreationTime = new(2020, 4, 12),
                        TaskName = "Manage employees",
                        TaskDescription = "John Smith should properly manage employees",
                        EmployeeId = 1,
                        Deadline = DateTime.Now
                    },
                    new DBO.Task
                    {
                        Id = 2,
                        CreationTime = new(2020, 5, 7),
                        TaskName = "Create software",
                        TaskDescription = "Phillip Walsh should create software",
                        EmployeeId = 2,
                        Deadline = DateTime.Now
                    },
                    new DBO.Task
                    {
                        Id = 3,
                        CreationTime = new(2020, 8, 13),
                        TaskName = "Create a product design",
                        TaskDescription = "Dora Williamson should create a great product design",
                        EmployeeId = 3,
                        Deadline = DateTime.Now
                    },
                    new DBO.Task
                    {
                        Id = 4,
                        CreationTime = new(2020, 1, 2),
                        TaskName = "Make a research",
                        TaskDescription = "Nadeem Liu should make a research",
                        EmployeeId = 4,
                        Deadline = DateTime.Now
                    }
                );
        }
        #endregion
    }
}
