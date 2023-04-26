using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.DAO
{
    public class CustomerProgressInfo
    {
        public int Id { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float BMI { get; set; }
        public float PerBodyFat { get; set; }
        public float PerMuscle { get; set; }
        public List<CustomerMeasures>? AnthropometricMeasurements { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CustomerId { get; set; }
    }
}