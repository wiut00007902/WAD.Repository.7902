using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementApplication.Models
{
    public class Region
    {
        [Display(Name = "Region ID")]
        // ID of the region
        public int Id { get; set; }
        // Data annotation that requires user to input region name with at least 2 symbols
        [Required(ErrorMessage = "Please, insert the name of the region"), MinLength(2, ErrorMessage = "Name of the region should be at least 2 symbols"), Display(Name = "Region name")]
        // Name of the region
        public string RegionName { get; set; }
        // Region creation date. Will be set automatically
        [Display(Name = "Creation date")]
        public DateTime CreationDate { get; set; }
    }
}
