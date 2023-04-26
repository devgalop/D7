using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.DAO
{
    public class PaymentPlanInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PayFrequency { get; set; } = string.Empty;
        public float Value { get; set; }
        public bool Status { get; set; }
    }
}