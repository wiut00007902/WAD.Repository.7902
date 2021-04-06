using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementApplication.DAL.DBO
{
    public class Region
    {
        public int Id { get; set; }

        [Required, MinLength(2)]
        public string RegionName { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
