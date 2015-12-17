using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentMe.Models
{
    public class Renter
    {       [Required]
            [Display(Name ="Building Number")]
            public string BuildNo { get; set; }

            [Required]
            [Display(Name = "Flat Number")]
            public string FlatNo { get; set; }

            [Required]
            [Display(Name = "Flat Type")]
            public string FlatType { get; set; }

            [Required]
            public int Rent { get; set; }

            [Required]
            [Display(Name = "Owner Name")]
            public string Name { get; set; }

            public string Email { get; set; }

            [Required]
            [Display(Name = "Mobile Number")]
            public string MobileNo { get; set; }

        
    }
}