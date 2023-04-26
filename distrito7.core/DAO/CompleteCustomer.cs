using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.DAO
{
    public class CompleteCustomer : SimpleCustomer
    {
        public CustomerPaymentPlan? Payment { get; set; }
        public List<CustomerProgressInfo>? Progress { get; set; }
    }
}