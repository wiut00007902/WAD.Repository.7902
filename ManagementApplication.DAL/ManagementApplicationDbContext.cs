using ManagementApplication.DAL.DBO;
using ManagementApplication.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApplication.DAL
{
    public class ManagementApplicationDbContext : DbContext
    {
        public ManagementApplicationDbContext(DbContextOptions<ManagementApplicationDbContext> options) : base(options)
        {
        }
        // Database sets.
        #region DbSet
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<DBO.Task> Tasks { get; set; }
        #endregion
        // Override OnModelCreating method. 
        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Method seeds the database with initial data.
            modelBuilder.Seed();
        }
        #endregion
    }
}
