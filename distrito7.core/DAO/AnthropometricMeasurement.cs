using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.DAO
{
    public class AnthropometricMeasurement
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UnitMeasurements { get; set; } = string.Empty;
    }
}