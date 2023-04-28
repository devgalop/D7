using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.DAO
{
    public class SelectCustomerByDate
    {
        public string DateSelected { get; set; } = string.Empty;
        public string DateFormat { get; set; } = string.Empty;
        public string CultureInfo { get; set; } = string.Empty;
    }
}