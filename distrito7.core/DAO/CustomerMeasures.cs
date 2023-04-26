using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.DAO
{
    public class CustomerMeasures
    {
        public int Id { get; set; }
        public AnthropometricMeasurement? AMDescription { get; set; }
        public float Value { get; set; }
        public int IdProgress { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}