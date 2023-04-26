using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.DAO
{
    public class AddCustomer
    {
        public string Name { get; set; } = string.Empty;
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Please make sure you enter a valid email address")]
        public string Email { get; set; } = string.Empty;
        [Range(10, 80)]
        public int Age { get; set; }
        public string Cellphone { get; set; } = string.Empty;
    }
}