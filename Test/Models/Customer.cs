using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Customer
    {
        // In order for the "Model State" to be valid we need both a first name and a last name (Required)

        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}