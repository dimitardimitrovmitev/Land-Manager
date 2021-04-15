using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Land
    {
        public int Id { get; set; }

        [StringLength(80)]
        [Required]
        public string Address { get; set; }


        [Range(1, 99999, ErrorMessage = "Invalid value.")]
        [Display(Name = "Area In Square Meters")]
        public int Area { get; set; }
        [Display(Name = "Monthly Rent In Euro")]
        [Range(0, 99999, ErrorMessage = "Invalid value.")]
        public int Rent { get; set; }
        public virtual IEnumerable<Customer> Customers { get; set; }

    }
}
