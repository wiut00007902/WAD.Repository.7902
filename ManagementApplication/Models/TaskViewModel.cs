using ManagementApplication.DAL.DBO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApplication.Models
{
    public class TaskViewModel : DAL.DBO.Task
    {
        public SelectList Employees { get; set; }
    }
}
