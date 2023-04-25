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
        public int IdNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Please make sure you enter a valid email address")]
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Cellphone { get; set; } = string.Empty;
        public DateTime RegisterAt { get; set; } = DateTime.Now;
        public List<CustomerProgress>? Progress { get; set; }
        public CustomerPayment? Payment { get; set; }
    }
}