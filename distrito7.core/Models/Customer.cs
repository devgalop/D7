using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public int IdNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Cellphone { get; set; } = string.Empty;
        public DateTime RegisterAt { get; set; } = DateTime.Now;
        public List<CustomerProgress>? Progress { get; set; }
        public CustomerPayment? Payment { get; set; }
    }
}