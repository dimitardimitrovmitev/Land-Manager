using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    /// <summary>
    /// Used to document the transactions made from tenants, i.e., paying rent
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Used to document the transactions made from tenants, i.e., paying rent
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The customer who made the payment
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// The amount of money given by the customer
        /// </summary>
        [Required]
        [Display(Name = "Amount In Euros")]
        [Range(1, 999999, ErrorMessage = "Invalid value.")]
        public double Cost   { get; set; }
        /// <summary>
        /// Date of the transaction
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
