using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    /// <summary>
    /// The object customers are assigned to and get their monthly rent decided by
    /// A single land can have multiple customers
    /// </summary>
    public class Land
    {
        /// <summary>
        /// Integer, that serves as an identification number for the object 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the address of the property (Location)
        /// </summary>
        [StringLength(80)]
        [Required]
        public string Address { get; set; }
        /// <summary>
        /// Area of the land, mesured in square meters
        /// </summary>
        [Range(1, 99999, ErrorMessage = "Invalid value.")]
        [Display(Name = "Area In Square Meters")]
        public int Area { get; set; }
        /// <summary>
        /// The monthly rent of the land
        /// </summary>
        [Display(Name = "Monthly Rent In Euro")]
        [Range(0, 99999, ErrorMessage = "Invalid value.")]
        public int Rent { get; set; }
        /// <summary>
        /// Reference to a list of customers, that have rented the property
        /// </summary>
        public virtual IEnumerable<Customer> Customers { get; set; }

    }
}
