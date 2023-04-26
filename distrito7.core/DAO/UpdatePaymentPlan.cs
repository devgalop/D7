using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.DAO
{
    public class UpdatePaymentPlan : AddPaymentPlan
    {
        public int Id { get; set; }
        public bool Status { get; set; }
    }
}