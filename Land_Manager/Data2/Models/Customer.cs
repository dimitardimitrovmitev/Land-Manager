using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Data.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Name must contain letters only.")]
        [MinLength(2, ErrorMessage = "The minimum length is 2")]
        
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Name must contain letters only.")]
        [MinLength(2, ErrorMessage = "The minimum length is 2")]
        public string LastName { get; set; }

        public string FullName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [EmailAddress]

        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(10)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public bool IsCancelled { get; set; }

        public DateTime DateOfRenting { get; set; }
        [Display(Name = "Rented Land")]
        public virtual Land RentedLand { get; set; }
        public virtual IEnumerable<Payment> Payments { get; set; }

    }
}
