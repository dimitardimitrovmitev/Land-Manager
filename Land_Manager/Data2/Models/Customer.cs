using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Data.Models
{
    /// <summary>
    /// Entity that occupies a single land and makes payments
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Integer, that serves as an identification number for the object 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// First name of the customer
        /// </summary>

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Name must contain letters only.")]
        [MinLength(2, ErrorMessage = "The minimum length is 2")]
        
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the customer
        /// </summary>
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Name must contain letters only.")]
        [MinLength(2, ErrorMessage = "The minimum length is 2")]
        public string LastName { get; set; }
        /// <summary>
        /// The first and last name of the customer, combined
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Personal email of the customer
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// Phone number of the customer
        /// </summary>
        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(10)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// The date, the customer have left the land
        /// </summary>
        public bool IsCancelled { get; set; }
        /// <summary>
        /// The date, the customer rented the land
        /// </summary>
        public DateTime DateOfRenting { get; set; }
        /// <summary>
        /// The land which the custommer have rented
        /// </summary>
        [Display(Name = "Rented Land")]
        public virtual Land RentedLand { get; set; }
        /// <summary>
        /// List of payments, the customer has made
        /// </summary>
        public virtual IEnumerable<Payment> Payments { get; set; }

    }
}
