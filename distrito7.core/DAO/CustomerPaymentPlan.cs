using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.DAO
{
    public class CustomerPaymentPlan
    {
        public int Id { get; set; }
        public DateTime PaidAt { get; set; }
        public DateTime EndsAt { get; set; }
        public PaymentPlanInfo? PlanSelected { get; set; }
        public int CustomerId { get; set; }
    }
}