using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApplication.Models
{
    public class Task
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime Daedline { get; set; }
        public string TaskDescription { get; set; }
    }
}
