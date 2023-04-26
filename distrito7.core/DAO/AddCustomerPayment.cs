using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.DAO
{
    public class AddCustomerPayment
    {
        public DateTime PaidAt { get; set; }
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
    }
}