using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.DAO
{
    public class SimpleCustomer
    {
        public int IdNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Cellphone { get; set; } = string.Empty;
        public DateTime RegisterAt { get; set; }
    }
}