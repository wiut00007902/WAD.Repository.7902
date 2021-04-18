using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementApplication.DAL.DBO
{
    public class Task
    {
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }
        public string TaskName { get; set; }
       public string TaskDescription { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public DateTime Deadline { get; set; }
    }
}
