using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.DAO
{
    public class AddCustomer
    {
        public int IdNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Range(10, 80)]
        public int Age { get; set; }
        public string Cellphone { get; set; } = string.Empty;
    }
}