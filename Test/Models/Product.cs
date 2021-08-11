using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Product
    {
        [Key]
        public string Sku { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public int NumberInInventory { get; set; }

        public bool IsInStock => this.NumberInInventory > 0;
    }
}