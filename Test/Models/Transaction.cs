using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey(nameof(Product))]
        public string Sku { get; set; }
        public Product Product { get; set; }

        public int ItemCount { get; set; }

        public DateTime DateOfTransaction { get; set; }
    }
}