using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementApplication.DAL.DBO
{
    public class Region
    {
        [Display(Name = "Region ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, insert the name of the region"), MinLength(2, ErrorMessage = "Name of the region should be at least 2 symbols"), Display(Name = "Region name")]
        public string RegionName { get; set; }
        [Display(Name = "Creation date")]
        public DateTime CreationDate { get; set; }
    }
}
